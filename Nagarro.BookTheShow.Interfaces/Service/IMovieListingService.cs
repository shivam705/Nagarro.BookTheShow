using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IMovieListingService
    {
        Task<IReadOnlyList<MovieListing>> GetAllMovieListingAsync();

        Task<MovieListing> GetMovieListingAsync(int id);

        Task<bool> CreateMovieListingAsync(MovieListing movieslot);

        Task<bool> UpdateMovieListingAsync(int id, MovieListing movieslot);

        Task<bool> DeleteMovieListingAsync(int id);
    }
}
