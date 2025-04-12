using Nagarro.BookTheShow.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Service
{
    public interface IMovieSlotService
    {
        Task<IReadOnlyList<MovieSlot>> GetAllMovieSlotAsync();

        Task<MovieSlot?> GetMovieSlotAsync(int id);

        Task<bool> CreateMovieSlotAsync(MovieSlot movieslot);

        Task<bool> UpdateMovieSlotAsync(int id, MovieSlot movieslot);

        Task<bool> DeleteMovieSlotAsync(int id);
    }
}
