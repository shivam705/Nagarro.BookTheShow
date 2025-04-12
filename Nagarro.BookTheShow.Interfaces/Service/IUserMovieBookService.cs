using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IUserMovieBookService
    {
        Task<IReadOnlyList<UserMovieBook>> GetAllUserMovieAsync();

        Task<UserMovieBook> GetUserMovieAsync(int id);

        Task<bool> CreateUserMovieAsync(UserMovieBook movie);

        Task<bool> UpdateUserMovieAsync(int id, UserMovieBook movie);

        Task<bool> DeleteUserMovieAsync(int id);
    }
}
