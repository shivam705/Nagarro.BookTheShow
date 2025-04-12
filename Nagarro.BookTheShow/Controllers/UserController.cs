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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET api/Register/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();

                var userDto = new UserDetail {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Contact = user.Contact,
                    Gender = user.Gender,
                    IsAdmin = user.IsAdmin
                };
                _logger.LogInformation("User Found");
                return Ok(userDto);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error retrieving user with ID {UserId}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // POST api/Register
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDetail userDto)
        {
            try {
                if (userDto == null)
                    return BadRequest("Invalid user data.");

                var user = new User {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    Contact = userDto.Contact,
                    Email = userDto.Email,
                    Password = userDto.Password, // BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                    IsAdmin = userDto.IsAdmin
                };

                await _userService.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, null);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error creating user.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT api/Register/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDetail userDto)
        {
            try {
                var existingUser = await _userService.GetUserByIdAsync(id);
                if (existingUser == null)
                    return NotFound();

                existingUser.FirstName = userDto.FirstName;
                existingUser.LastName = userDto.LastName;
                existingUser.Gender = userDto.Gender;
                existingUser.Contact = userDto.Contact;
                existingUser.Email = userDto.Email;
                existingUser.IsAdmin = userDto.IsAdmin;

                var updated = await _userService.UpdateUserAsync(id, existingUser);
                if (!updated)
                    return StatusCode(500, "Failed to update user.");

                return NoContent();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error updating user with ID {UserId}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE api/Register/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound();

                var deleted = await _userService.DeleteUserAsync(id);
                if (!deleted)
                    return StatusCode(500, "Failed to delete user.");

                return NoContent();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error deleting user with ID {UserId}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
