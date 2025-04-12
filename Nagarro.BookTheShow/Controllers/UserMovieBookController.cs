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
    public class UserMovieBookController : ControllerBase
    {
        private readonly IUserMovieBookService _usermovieBookService;
        private readonly ILogger<UserMovieBookController> _logger;

        public UserMovieBookController(IUserMovieBookService userService, ILogger<UserMovieBookController> logger)
        {
            _usermovieBookService = userService;
            _logger = logger;
        }

        // GET: api/<MovieDetailController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMovieBookDetail>>> GetAllUserMovie()
        {
            try
            {
                _logger.LogInformation("Getting all user movies");
                var movies = await _usermovieBookService.GetAllUserMovieAsync();
                return movies.Select(x => new UserMovieBookDetail
                {
                    Id = x.Id,
                    MovieSlotId = x.MovieSlotId,
                    UserId = x.UserId,
                    SeatNos = x.SeatNos,
                    IsActive = x.IsActive,
                    NoOfTickets = x.NoOfTickets,
                    BookingDate = x.BookingDate,
                    Rating = x.Rating
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all user movies");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserMovie([FromBody] UserMovieBookDetail movieDetails)
        {
            try
            {
                _logger.LogInformation("Creating a new user movie");
                var movie = new Interfaces.Domain.UserMovieBook
                {
                    MovieSlotId = movieDetails.MovieSlotId,
                    UserId = movieDetails.UserId,
                    SeatNos = movieDetails.SeatNos,
                    NoOfTickets = movieDetails.NoOfTickets,
                    BookingDate = movieDetails.BookingDate,
                    Rating = movieDetails.Rating,
                    IsActive = movieDetails.IsActive
                };
                var result = await _usermovieBookService.CreateUserMovieAsync(movie);
                if (result)
                {
                    _logger.LogInformation("User movie created successfully");
                    return Ok();
                }
                _logger.LogWarning("Failed to create user movie");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new user movie");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET api/<MovieDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMovieBookDetail>> GetUserMovie(int id)
        {
            try
            {
                _logger.LogInformation($"Getting user movie with id {id}");
                var movieBook = await _usermovieBookService.GetUserMovieAsync(id);
                if (movieBook == null)
                {
                    _logger.LogWarning($"User movie with id {id} not found");
                    return NotFound();
                }
                var movieBookDetails = new UserMovieBookDetail
                {
                    Id = movieBook.Id,
                    UserId = movieBook.UserId,
                    MovieSlotId = movieBook.MovieSlotId,
                    SeatNos = movieBook.SeatNos,
                    IsActive = movieBook.IsActive,
                    NoOfTickets = movieBook.NoOfTickets,
                    BookingDate = movieBook.BookingDate,
                    Rating = movieBook.Rating
                };
                return movieBookDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user movie with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE api/<MovieDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserMovie(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting user movie with id {id}");
                var movie = await _usermovieBookService.GetUserMovieAsync(id);
                if (movie == null)
                {
                    _logger.LogWarning($"User movie with id {id} not found");
                    return NotFound();
                }
                var result = await _usermovieBookService.DeleteUserMovieAsync(id);
                if (result)
                {
                    _logger.LogInformation($"User movie with id {id} deleted successfully");
                    return Ok();
                }
                _logger.LogWarning($"Failed to delete user movie with id {id}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting user movie with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
