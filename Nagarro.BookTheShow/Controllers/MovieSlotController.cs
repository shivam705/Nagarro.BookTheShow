using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nagarro.BookTheShow.Interfaces.Service;
using Nagarro.BookTheShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSlotController : ControllerBase
    {
        private readonly IMovieSlotService _movieslotService;
        private readonly ILogger<MovieSlotController> _logger;

        public MovieSlotController(IMovieSlotService movieslotService, ILogger<MovieSlotController> logger)
        {
            _movieslotService = movieslotService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MovieSlotDetail>>> GetAllMovieSlot()
        {
            try
            {
                var movieSlots = await _movieslotService.GetAllMovieSlotAsync();
                return movieSlots.Select(x => new MovieSlotDetail
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    MovieTime = x.MovieTime,
                    MovieDate = x.MovieDate,
                    Fare = x.Fare,
                    MaxSeats = x.MaxSeats,
                    AvailableSeats = x.AvailableSeats
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all movie slots.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieSlotDetail>> GetMovieSlot(int id)
        {
            try
            {
                var movieslot = await _movieslotService.GetMovieSlotAsync(id);
                if (movieslot == null)
                    return NotFound();

                var movieslotDetails = new MovieSlotDetail
                {
                    Id = movieslot.Id,
                    MovieId = movieslot.MovieId,
                    MovieTime = movieslot.MovieTime,
                    Fare = movieslot.Fare,
                    MovieDate = movieslot.MovieDate,
                    MaxSeats = movieslot.MaxSeats,
                    AvailableSeats = movieslot.AvailableSeats
                };
                return movieslotDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting movie slot with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovieSlot([FromBody] MovieSlotDetail movieslotDetails)
        {
            try
            {
                var movieslot = new Interfaces.Domain.MovieSlot
                {
                    MovieId = movieslotDetails.MovieId,
                    MovieTime = movieslotDetails.MovieTime,
                    Fare = movieslotDetails.Fare,
                    MovieDate = movieslotDetails.MovieDate,
                    MaxSeats = movieslotDetails.MaxSeats,
                    AvailableSeats = movieslotDetails.AvailableSeats
                };
                await _movieslotService.CreateMovieSlotAsync(movieslot);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating movie slot.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovieSlot(int id, [FromBody] MovieSlotDetail movieslotDetails)
        {
            try
            {
                var movieslot = await _movieslotService.GetMovieSlotAsync(id);
                if (movieslot == null)
                    return NotFound();

                movieslot.MovieId = movieslotDetails.MovieId;
                movieslot.MovieTime = movieslotDetails.MovieTime;
                movieslot.Fare = movieslotDetails.Fare;
                movieslot.MovieDate = movieslotDetails.MovieDate;
                movieslot.MaxSeats = movieslotDetails.MaxSeats;
                movieslot.AvailableSeats = movieslotDetails.AvailableSeats;

                await _movieslotService.UpdateMovieSlotAsync(id, movieslot);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating movie slot with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovieSlot(int id)
        {
            try
            {
                var movieslot = await _movieslotService.GetMovieSlotAsync(id);
                if (movieslot == null)
                    return NotFound();

                await _movieslotService.DeleteMovieSlotAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting movie slot with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
