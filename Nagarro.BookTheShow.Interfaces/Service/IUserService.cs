using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IUserService
    {
        Task<IReadOnlyList<User>> GetAllUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task<bool> CreateUserAsync(User user);

        Task<bool> UpdateUserAsync(int id, User user);

        Task<bool> DeleteUserAsync(int id);

        Task<User?> GetUserByEmailAsync(string email, string password);
        
    }
}
