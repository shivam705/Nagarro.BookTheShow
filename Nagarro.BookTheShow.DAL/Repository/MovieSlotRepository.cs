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
    public class MovieSlotRepository : IMovieSlotRepository
    {
        private readonly BookTheShowContext _dbContext;

        public MovieSlotRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateMovieSlotAsync(MovieSlot movieslot)
        {
            EFModels.MovieSlot st = new EFModels.MovieSlot
            {
                MovieId = movieslot.MovieId,
                MovieTime = movieslot.MovieTime,
                Fare = movieslot.Fare,
                MovieDate = movieslot.MovieDate,
                MaxSeats = movieslot.MaxSeats,
                AvailableSeats = movieslot.AvailableSeats
            };
            await _dbContext.AddAsync(st);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieSlotAsync(int id)
        {
            var movieSlot = await _dbContext.MovieSlots.FirstOrDefaultAsync(x => x.Id == id);
            if (movieSlot != null)
            {
                _dbContext.Remove(movieSlot);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IReadOnlyList<MovieSlot>> GetAllMovieSlotAsync()
        {
            return await _dbContext.MovieSlots
                .Select(x => new MovieSlot
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    MovieTime = x.MovieTime,
                    Fare = x.Fare,
                    MovieDate = x.MovieDate,
                    MaxSeats = x.MaxSeats,
                    AvailableSeats = x.AvailableSeats
                })
                .ToListAsync();
        }

        public async Task<MovieSlot> GetMovieSlotAsync(int id)
        {
            return await _dbContext.MovieSlots
                .Where(x => x.Id == id)
                .Select(x => new MovieSlot
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    MovieTime = x.MovieTime,
                    Fare = x.Fare,
                    MovieDate = x.MovieDate,
                    MaxSeats = x.MaxSeats,
                    AvailableSeats = x.AvailableSeats
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMovieSlotAsync(int id, MovieSlot movieslot)
        {
            var movieslotIndex = await _dbContext.MovieSlots.FirstOrDefaultAsync(x => x.Id == id);
            if (movieslotIndex != null)
            {
                movieslotIndex.MovieId = movieslot.MovieId;
                movieslotIndex.MovieTime = movieslot.MovieTime;
                movieslotIndex.Fare = movieslot.Fare;
                movieslotIndex.MovieDate = movieslot.MovieDate;
                movieslotIndex.MaxSeats = movieslot.MaxSeats;
                movieslotIndex.AvailableSeats = movieslot.AvailableSeats;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
