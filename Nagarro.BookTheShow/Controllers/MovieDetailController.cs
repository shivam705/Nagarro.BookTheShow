using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nagarro.BookTheShow.Interfaces.Domain;
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
    public class MovieDetailController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieDetailController> _logger;

        public MovieDetailController(IMovieService userService, ILogger<MovieDetailController> logger)
        {
            _movieService = userService;
            _logger = logger;
        }

        // GET: api/<MovieDetailController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDetail>>> GetAllMovie()
        {
            try
            {
                var movies = await _movieService.GetAllMovieAsync();
                return movies.Select(x => new MovieDetail { Id = x.Id, MovieName = x.MovieName, MovieDescription = x.MovieDescription, MovieImage = x.MovieImage, IsActive = x.IsActive }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all movies.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetail>> GetMovie(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieAsync(id);
                if (movie == null)
                    return NotFound();
                var movieDetails = new MovieDetail { Id = movie.Id, MovieName = movie.MovieName, MovieDescription = movie.MovieDescription, MovieImage = movie.MovieImage, IsActive = movie.IsActive };
                return movieDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting movie with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<MovieDetailController>
        [HttpPost]
        public async Task<ActionResult> CreateMovie([FromBody] MovieDetail movieDetails)
        {
            try
            {
                var movie = new Movie
                {
                    MovieName = movieDetails.MovieName,
                    MovieDescription = movieDetails.MovieDescription,
                    MovieImage = movieDetails.MovieImage,
                    IsActive = movieDetails.IsActive
                };
                await _movieService.CreateMovieAsync(movie);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a movie.");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<MovieDetailController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] MovieDetail movieDetails)
        {
            try
            {
                var movie = await _movieService.GetMovieAsync(id);
                if (movie == null)
                    return NotFound();
                movie.MovieName = movieDetails.MovieName;
                movie.MovieDescription = movieDetails.MovieDescription;
                movie.MovieImage = movieDetails.MovieImage;
                movie.IsActive = movieDetails.IsActive;
                await _movieService.UpdateMovieAsync(id, movie);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating movie with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieAsync(id);
                if (movie == null)
                    return NotFound();
                await _movieService.DeleteMovieAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting movie with id {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
