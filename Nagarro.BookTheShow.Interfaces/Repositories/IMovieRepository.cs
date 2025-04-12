using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IReadOnlyList<Movie>> GetAllMovieAsync();

        Task<Movie> GetMovieAsync(int id);

        Task<bool> CreateMovieAsync(Movie movie);

        Task<bool> UpdateMovieAsync(int id, Movie movie);

        Task<bool> DeleteMovieAsync(int id);
    }
}
