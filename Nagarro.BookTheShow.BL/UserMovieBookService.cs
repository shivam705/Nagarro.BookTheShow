using Nagarro.BookTheShow.Interfaces.Domain;
using Nagarro.BookTheShow.Interfaces.Repositories;
using Nagarro.BookTheShow.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.BL
{
    public class UserMovieBookService : IUserMovieBookService
    {
        private readonly IUserMovieBookRepository _userMovies;

        public UserMovieBookService(IUserMovieBookRepository userMovies)
        {
            _userMovies = userMovies;
        }

        public Task<bool> CreateUserMovieAsync(UserMovieBook movie)
        {
            return _userMovies.CreateUserMovieAsync(movie);
        }

        public Task<bool> DeleteUserMovieAsync(int id)
        {
            return _userMovies.DeleteUserMovieAsync(id);
        }

        public Task<IReadOnlyList<UserMovieBook>> GetAllUserMovieAsync()
        {
            return _userMovies.GetAllUserMovieAsync();
        }

        public Task<UserMovieBook> GetUserMovieAsync(int id)
        {
            return _userMovies.GetUserMovieAsync(id);
        }

        public Task<bool> UpdateUserMovieAsync(int id, UserMovieBook movie)
        {
            return _userMovies.UpdateUserMovieAsync(id, movie);
        }
    }
}
