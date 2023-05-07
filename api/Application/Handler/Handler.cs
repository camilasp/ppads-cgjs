using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.DTO;

namespace Application.Handler
{
    public sealed class Handler : IHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;
        private readonly IMovieClient _movieClient;

        public Handler(IMovieClient movieClient, IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
            _movieClient = movieClient;
        }

        public async Task<bool> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                if (!await _uof.UserRepository.HasUserWithEmailAsync(userDTO.Email))
                {
                    var user = _mapper.Map<User>(userDTO);
                    _uof.UserRepository.Add(user);
                    await _uof.Commit();
                    return true;
                }
                else
                {
                    throw new Exception("Usuário já existe.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Falha ao criar um novo usuário.");
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid guid)
        {
            try
            {
                var user = await _uof.UserRepository.GetPredicateAsync(x => x.Id == guid);

                if (user is not null)
                {
                    return _mapper.Map<UserDTO>(user);
                }

                return null;
            }
            catch (Exception)
            {
                throw new Exception("Falha ao pegar usuário.");
            }
        }

        public async Task<UserDTO> LoginUserAsync(string email, string password)
        {
            try
            {
                var user = await _uof.UserRepository.CheckUserCredentialsAsync(email, password);

                if (user is not null)
                {
                    return _mapper.Map<UserDTO>(user);
                }

                return null;
            }
            catch (Exception)
            {
                throw new Exception("Falha ao logar usuário.");
            }
        }

        public async Task UpdateUserMovieListAsync(UpdateMovieListDTO updateMovieListDTO)
        {
            try
            {
                var user = await _uof.UserRepository.GetPredicateAsync(user => user.Id == updateMovieListDTO.UserId);

                if (user is not null)
                {
                    if (user.MovieReferences is not null)
                    {
                        MovieReference? movieRef = await _uof.MovieReferenceRepository.GetPredicateAsync(x => x.UserId == user.Id && x.MovieId == updateMovieListDTO.MovieId);

                        if (movieRef is not null && !updateMovieListDTO.Favorite)
                        {
                            _uof.MovieReferenceRepository.Delete(movieRef);
                        }
                        else if (movieRef is null && updateMovieListDTO.Favorite)
                        {
                            _uof.MovieReferenceRepository.Add(new MovieReference { Id = Guid.NewGuid(), UserId = user.Id, MovieId = updateMovieListDTO.MovieId, User = user });
                        }
                    }
                    else if (updateMovieListDTO.Favorite)
                    {
                        _uof.MovieReferenceRepository.Add(new MovieReference { Id = Guid.NewGuid(), UserId = user.Id, MovieId = updateMovieListDTO.MovieId, User = user });
                    }

                    await _uof.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar um usuário.");
            }
        }

        public async Task DeleteUserAsync(Guid guid)
        {
            try
            {
                var user = await _uof.UserRepository.GetPredicateAsync(user => user.Id == guid);
                _uof.UserRepository.Delete(user);
                await _uof.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar um usuário.");
            }
        }

        public async Task<ICollection<MinimalMovieDTO>> GetPopularMoviesAsync()
        {
            try
            {
                var moviesInfo = await _movieClient.GetPopularMoviesAsync();
                return _mapper.Map<ICollection<MinimalMovieDTO>>(moviesInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha em pegar filmes populares.");
            }
        }

        public async Task<MovieFavDTO> GetMovieByIdAsync(Guid guid, int id)
        {
            try
            {
                bool fav = false;
                var movie = await _movieClient.GetMovieByIdAsync(id);

                if (guid != Guid.Empty)
                {
                    var user = await _uof.UserRepository.GetPredicateAsync(user => user.Id == guid);

                    if (user.MovieReferences is not null)
                    {
                        if (user.MovieReferences.Count > 0)
                        {
                            if (user?.MovieReferences.Any(movie => movie.MovieId == id) == true)
                            {
                                fav = true;
                            }
                        }
                    }
                }

                MovieFavDTO movieFav = new()
                {
                    itsFavorited = fav,
                    movie = movie
                };

                return movieFav;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha em pegar filme.");
            }
        }

        public async Task<ICollection<MinimalMovieDTO>> RandomMovieById(int genrer)
        {
            try
            {
                var moviesInfo = await _movieClient.GetRandomMovieByGenrerAsync(genrer);
                return _mapper.Map<ICollection<MinimalMovieDTO>>(moviesInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha em pegar filmes aleatorios.");
            }
        }
    }
}
