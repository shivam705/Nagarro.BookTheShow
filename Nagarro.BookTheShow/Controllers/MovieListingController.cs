using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nagarro.BookTheShow.Interfaces.Service;
using Nagarro.BookTheShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nagarro.BookTheShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListingController : ControllerBase
    {
        private readonly IMovieListingService _movieslotService;
        private readonly ILogger<MovieListingController> _logger;

        public MovieListingController(IMovieListingService movieslotService, ILogger<MovieListingController> logger)
        {
            _movieslotService = movieslotService;
            _logger = logger;
        }

        // GET: api/<MovieListingController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieListing>>> GetAllMovieListing()
        {
            try
            {
                var movieListings = await _movieslotService.GetAllMovieListingAsync();
                return Ok(movieListings.Select(x => new MovieListing
                {
                    Id = x.Id,
                    MovieName = x.MovieName,
                    MovieDescription = x.MovieDescription,
                    MovieImage = x.MovieImage,
                    MovieTime = x.MovieTime,
                    MovieDate = x.MovieDate,
                    Fare = x.Fare,
                    MaxSeats = x.MaxSeats,
                    AvailableSeats = x.AvailableSeats
                }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all movie listings.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieListing>> GetMovieListing(int id)
        {
            try
            {
                var movieslot = await _movieslotService.GetMovieListingAsync(id);
                if (movieslot == null)
                    return NotFound();

                var movieslotDetails = new MovieListing
                {
                    Id = movieslot.Id,
                    MovieName = movieslot.MovieName,
                    MovieDescription = movieslot.MovieDescription,
                    MovieImage = movieslot.MovieImage,
                    MovieTime = movieslot.MovieTime,
                    Fare = movieslot.Fare,
                    MovieDate = movieslot.MovieDate,
                    MaxSeats = movieslot.MaxSeats,
                    AvailableSeats = movieslot.AvailableSeats
                };
                return Ok(movieslotDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting movie listing with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<MovieDetailController>
        [HttpPost]
        public async Task<ActionResult> CreateMovieListing([FromBody] MovieListing movieslotDetails)
        {
            try
            {
                var movieslot = new Interfaces.Domain.MovieListing
                {
                    MovieName = movieslotDetails.MovieName,
                    MovieDescription = movieslotDetails.MovieDescription,
                    MovieImage = movieslotDetails.MovieImage,
                    MovieTime = movieslotDetails.MovieTime,
                    Fare = movieslotDetails.Fare,
                    MovieDate = movieslotDetails.MovieDate,
                    MaxSeats = movieslotDetails.MaxSeats,
                    AvailableSeats = movieslotDetails.AvailableSeats
                };
                var result = await _movieslotService.CreateMovieListingAsync(movieslot);
                if (!result)
                    return StatusCode(500, "A problem happened while handling your request.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating movie listing.");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<MovieDetailController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovieListing(int id, [FromBody] MovieListing movieslotDetails)
        {
            try
            {
                var movieslot = await _movieslotService.GetMovieListingAsync(id);
                if (movieslot == null)
                    return NotFound();

                movieslot.MovieName = movieslotDetails.MovieName;
                movieslot.MovieDescription = movieslotDetails.MovieDescription;
                movieslot.MovieImage = movieslotDetails.MovieImage;
                movieslot.MovieTime = movieslotDetails.MovieTime;
                movieslot.Fare = movieslotDetails.Fare;
                movieslot.MovieDate = movieslotDetails.MovieDate;
                movieslot.MaxSeats = movieslotDetails.MaxSeats;
                movieslot.AvailableSeats = movieslotDetails.AvailableSeats;

                var result = await _movieslotService.UpdateMovieListingAsync(id, movieslot);
                if (!result)
                    return StatusCode(500, "A problem happened while handling your request.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating movie listing with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovieListing(int id)
        {
            try
            {
                var movieslot = await _movieslotService.GetMovieListingAsync(id);
                if (movieslot == null)
                    return NotFound();

                var result = await _movieslotService.DeleteMovieListingAsync(id);
                if (!result)
                    return StatusCode(500, "A problem happened while handling your request.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting movie listing with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
