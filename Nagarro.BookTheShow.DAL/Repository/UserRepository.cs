using Microsoft.EntityFrameworkCore;
using Nagarro.BookTheShow.DAL.Data.DbContexts;
using Nagarro.BookTheShow.Interfaces.Domain;
using Nagarro.BookTheShow.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookTheShowContext _dbContext;

        public UserRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (await GetUserByEmailAsync(user.Email, user.Password) != null)
                return false; // User already exists

            var newUser = new EFModels.User {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Email = user.Email,
                Contact = user.Contact,
                Password = user.Password//BCrypt.Net.BCrypt.HashPassword(user.Password) // Secure password hashing
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return false;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users
                .Select(x => new User {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    Email = x.Email,
                    Contact = x.Contact,
                    IsAdmin = x.IsAdmin
                })
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users
                .Where(x => x.Id == id)
                .Select(x => new User {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    Email = x.Email,
                    Contact = x.Contact,
                    IsAdmin = x.IsAdmin
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);
            if (existingUser == null)
                return false;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Gender = user.Gender;
            existingUser.Email = user.Email;
            existingUser.Contact = user.Contact;
            existingUser.IsAdmin = user.IsAdmin;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserByEmailAsync(string email, string password)
        {
            return await _dbContext.Users
                .Where(x => x.Email == email)
                .Select(x => new User {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    Email = x.Email,
                    Contact = x.Contact,
                    IsAdmin = x.IsAdmin
                })
                .FirstOrDefaultAsync();
        }

    }
}
