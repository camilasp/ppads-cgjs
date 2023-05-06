using Application.Interfaces;
using AutoMapper;
using DM.MovieApi.MovieDb.Movies;
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
                if (await _uof.UserRepository.HasUserWithEmailAsync(userDTO.Email))
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
                    var movieRef = user.MovieReferences.FirstOrDefault(mr => mr.MovieId == updateMovieListDTO.MovieId);

                    if (movieRef != null && !updateMovieListDTO.Favorite)
                    {
                        user.MovieReferences.Remove(movieRef);
                    }
                    else if (updateMovieListDTO.Favorite)
                    {
                        if (movieRef == null)
                        {
                            movieRef = new MovieReference { Id = Guid.NewGuid(), UserId = user.Id };
                            user.MovieReferences.Add(movieRef);
                        }

                        movieRef.MovieId = updateMovieListDTO.MovieId;
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
                var movieInfo = _mapper.Map<MovieInfo>(movie);

                if (guid != Guid.Empty)
                {
                    var user = await _uof.UserRepository.GetPredicateAsync(user => user.Id == guid);

                    if (user?.MovieReferences.Any(movie => movie.MovieId == id) == true)
                    {
                        fav = true;
                    }
                }

                MovieFavDTO movieFav = new()
                {
                    itsFavorited = fav,
                    movieInfo = movieInfo
                };

                return movieFav;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha em pegar filme.");
            }
        }
    }
}
