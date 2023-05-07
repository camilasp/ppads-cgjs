using AutoMapper;
using DM.MovieApi.MovieDb.Movies;
using Domain.Entities;
using Domain.Entities.DTO;

namespace Application.Mapper
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.MovieReferences.Select(id => id.MovieId)));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.MovieReferences, opt => opt.MapFrom(src => src.Movies.Select(movieId => new MovieReference { Id = Guid.NewGuid(), MovieId = movieId, UserId = src.Id})));

            CreateMap<MovieInfo, MinimalMovieDTO>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(genre => genre.Name)));

            CreateMap<Movie, MovieInfo>();
        }
    }
}
