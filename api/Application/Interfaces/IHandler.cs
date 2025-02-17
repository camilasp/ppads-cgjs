﻿using Domain.Entities.DTO;

namespace Application.Interfaces
{
    public interface IHandler
    {
        Task<UserDTO> GetUserByIdAsync(Guid guid);
        Task<bool> CreateUserAsync(UserDTO userDTO);
        Task<UserDTO> LoginUserAsync(string email, string password);
        Task UpdateUserMovieListAsync(UpdateMovieListDTO updateMovieListDTO);
        Task DeleteUserAsync(Guid guid);

        Task<ICollection<MinimalMovieDTO>> GetPopularMoviesAsync();
        Task<MovieFavDTO> GetMovieByIdAsync(Guid guid, int id);

        Task<ICollection<MinimalMovieDTO>> RandomMovieById(int genrer);
    }
}
