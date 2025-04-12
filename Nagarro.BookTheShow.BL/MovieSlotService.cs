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
    public class MovieSlotService : IMovieSlotService
    {
        private readonly IMovieSlotRepository _movieslotRepository;

        public MovieSlotService(IMovieSlotRepository movieslotRepository)
        {
            _movieslotRepository = movieslotRepository;
        }

        public async Task<bool> CreateMovieSlotAsync(MovieSlot movieslot)
        {
            return await _movieslotRepository.CreateMovieSlotAsync(movieslot);
        }

        public async Task<bool> DeleteMovieSlotAsync(int id)
        {
            return await _movieslotRepository.DeleteMovieSlotAsync(id);
        }

        public async Task<IReadOnlyList<MovieSlot>> GetAllMovieSlotAsync()
        {
            return await _movieslotRepository.GetAllMovieSlotAsync();
        }

        public async Task<MovieSlot> GetMovieSlotAsync(int id)
        {
            return await _movieslotRepository.GetMovieSlotAsync(id);
        }

        public async Task<bool> UpdateMovieSlotAsync(int id, MovieSlot movieslot)
        {
            return await _movieslotRepository.UpdateMovieSlotAsync(id, movieslot);
        }
    }
}
