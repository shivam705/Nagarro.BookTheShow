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
    public class MovieListingRepository : IMovieListingRepository
    {
        private readonly BookTheShowContext _dbContext;

        public MovieListingRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateMovieListingAsync(MovieListing movieslot)
        {
            EFModels.MovieListing st = new EFModels.MovieListing
            {
                MovieName = movieslot.MovieName,
                MovieDescription = movieslot.MovieDescription,
                MovieImage = movieslot.MovieImage,
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

        public async Task<bool> DeleteMovieListingAsync(int id)
        {
            var movieListing = await _dbContext.MovieListings.FirstOrDefaultAsync(x => x.Id == id);
            if (movieListing != null)
            {
                _dbContext.Remove(movieListing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IReadOnlyList<MovieListing>> GetAllMovieListingAsync()
        {
            return await _dbContext.MovieListings.Select(x => new MovieListing
            {
                Id = x.Id,
                MovieName = x.MovieName,
                MovieImage = x.MovieImage,
                MovieDescription = x.MovieDescription,
                MovieTime = x.MovieTime,
                Fare = x.Fare,
                MovieDate = x.MovieDate,
                MaxSeats = x.MaxSeats,
                AvailableSeats = x.AvailableSeats
            }).ToListAsync();
        }

        public async Task<MovieListing> GetMovieListingAsync(int id)
        {
            return await _dbContext.MovieListings.Where(x => x.Id == id).Select(x => new MovieListing
            {
                Id = x.Id,
                MovieName = x.MovieName,
                MovieDescription = x.MovieDescription,
                MovieImage = x.MovieImage,
                MovieTime = x.MovieTime,
                Fare = x.Fare,
                MovieDate = x.MovieDate,
                MaxSeats = x.MaxSeats,
                AvailableSeats = x.AvailableSeats
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMovieListingAsync(int id, MovieListing movieslot)
        {
            var movieslotIndex = await _dbContext.MovieListings.FirstOrDefaultAsync(x => x.Id == id);
            if (movieslotIndex != null)
            {
                movieslotIndex.MovieName = movieslot.MovieName;
                movieslotIndex.MovieDescription = movieslot.MovieDescription;
                movieslotIndex.MovieImage = movieslot.MovieImage;
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
