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
    public class MovieListingService : IMovieListingService
    {
        private readonly IMovieListingRepository _movieRepository;

        public MovieListingService(IMovieListingRepository userRepository)
        {
            _movieRepository = userRepository;
        }


        public Task<bool> CreateMovieListingAsync(MovieListing movieslot)
        {
            return _movieRepository.CreateMovieListingAsync(movieslot);
        }

        public Task<bool> DeleteMovieListingAsync(int id)
        {
            return _movieRepository.DeleteMovieListingAsync(id);
        }

        public Task<IReadOnlyList<MovieListing>> GetAllMovieListingAsync()
        {
            return _movieRepository.GetAllMovieListingAsync();
        }

        public Task<MovieListing> GetMovieListingAsync(int id)
        {
           return _movieRepository.GetMovieListingAsync(id);
        }

        public Task<bool> UpdateMovieListingAsync(int id, MovieListing movieslot)
        {
            return _movieRepository.UpdateMovieListingAsync(id, movieslot);
        }
    }
}
