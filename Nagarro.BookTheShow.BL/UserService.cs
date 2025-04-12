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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IReadOnlyList<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public Task<bool> CreateUserAsync(User user)
        {
            return _userRepository.CreateUserAsync(user);
        }

        public Task<bool> UpdateUserAsync(int id, User user)
        {
           return  _userRepository.UpdateUserAsync(id, user);
        }

        public Task<bool> DeleteUserAsync(int id)
        {
           return _userRepository.DeleteUserAsync(id);
        }

        public Task<User> GetUserByEmailAsync(string email, string password)
        {
           return _userRepository.GetUserByEmailAsync(email, password);
        }
    }
}
