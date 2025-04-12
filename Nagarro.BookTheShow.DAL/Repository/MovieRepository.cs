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
    public class MovieRepository : IMovieRepository
    {
        private readonly BookTheShowContext _dbContext;

        public MovieRepository(BookTheShowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            EFModels.Movie st = new EFModels.Movie 
            {
                MovieName = movie.MovieName, 
                MovieDescription = movie.MovieDescription, 
                MovieImage = movie.MovieImage, 
                IsActive = movie.IsActive 
            };
            await _dbContext.AddAsync(st);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie != null)
            {
                _dbContext.Remove(movie);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IReadOnlyList<Movie>> GetAllMovieAsync()
        {
            return await _dbContext.Movies.Select(x => new Movie { Id = x.Id, MovieName = x.MovieName, MovieDescription = x.MovieDescription, MovieImage = x.MovieImage, IsActive = x.IsActive }).ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _dbContext.Movies.Where(x => x.Id == id).Select(x => new Movie { Id = x.Id, MovieName = x.MovieName, MovieDescription = x.MovieDescription, MovieImage = x.MovieImage, IsActive = x.IsActive }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMovieAsync(int id, Movie movie)
        {
            var movieIndex = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieIndex != null)
            {
                movieIndex.MovieName = movie.MovieName;
                movieIndex.MovieDescription = movie.MovieDescription;
                movieIndex.MovieImage = movie.MovieImage;
                movieIndex.IsActive = movie.IsActive;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
