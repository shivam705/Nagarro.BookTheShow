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
    public class UserMovieBookRepository : IUserMovieBookRepository
    {
        private readonly BookTheShowContext _dbContext;

        public UserMovieBookRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateUserMovieAsync(UserMovieBook movie)
        {
            EFModels.UserMovieBook st = new EFModels.UserMovieBook { MovieSlotId = movie.MovieSlotId, UserId = movie.UserId, SeatNos = movie.SeatNos, IsActive = movie.IsActive, NoOfTickets = movie.NoOfTickets, BookingDate = movie.BookingDate, Rating = movie.Rating };
            await _dbContext.AddAsync(st);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserMovieAsync(int id)
        {
            var userMovieBook = await _dbContext.UserMovieBooks.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (userMovieBook != null)
            {
                _dbContext.UserMovieBooks.Remove(userMovieBook);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IReadOnlyList<UserMovieBook>> GetAllUserMovieAsync()
        {
            return await _dbContext.UserMovieBooks
                .Select(x => new UserMovieBook
                {
                    Id = x.Id,
                    MovieSlotId = x.MovieSlotId,
                    UserId = x.UserId,
                    SeatNos = x.SeatNos,
                    IsActive = x.IsActive,
                    NoOfTickets = x.NoOfTickets,
                    BookingDate = x.BookingDate,
                    Rating = x.Rating
                })
                .ToListAsync();
        }

        public async Task<UserMovieBook> GetUserMovieAsync(int id)
        {
            return await _dbContext.UserMovieBooks
                .Where(x => x.Id == id)
                .Select(x => new UserMovieBook
                {
                    Id = x.Id,
                    MovieSlotId = x.MovieSlotId,
                    UserId = x.UserId,
                    SeatNos = x.SeatNos,
                    IsActive = x.IsActive,
                    NoOfTickets = x.NoOfTickets,
                    BookingDate = x.BookingDate,
                    Rating = x.Rating
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserMovieAsync(int id, UserMovieBook movie)
        {
            var movieIndex = await _dbContext.UserMovieBooks.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (movieIndex != null)
            {
                movieIndex.SeatNos = movie.SeatNos;
                movieIndex.NoOfTickets = movie.NoOfTickets;
                movieIndex.BookingDate = movie.BookingDate;
                movieIndex.IsActive = movie.IsActive;
                movieIndex.Rating = movie.Rating;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
