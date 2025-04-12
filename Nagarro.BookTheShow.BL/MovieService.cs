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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public  MovieService(IMovieRepository userRepository)
        {
            _movieRepository = userRepository;
        }

        public Task<bool> CreateMovieAsync(Movie movie)
        {
            return _movieRepository.CreateMovieAsync(movie);
        }

        public Task<bool> DeleteMovieAsync(int id)
        {
           return _movieRepository.DeleteMovieAsync(id);
        }

        public Task<IReadOnlyList<Movie>> GetAllMovieAsync()
        {
            return _movieRepository.GetAllMovieAsync();
        }

        public Task<Movie> GetMovieAsync(int id)
        {
            return _movieRepository.GetMovieAsync(id);
        }

        public Task<bool> UpdateMovieAsync(int id, Movie movie)
        {
            return _movieRepository.UpdateMovieAsync(id, movie);
        }
    }
}
