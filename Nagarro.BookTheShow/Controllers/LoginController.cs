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
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUserService userService, ILogger<LoginController> logger)
        {
            _userService = userService;
            _logger = logger;

        }

        // GET api/<LoginController>/5
        [HttpGet("{email}")]
        public async Task<ActionResult<UserDetail>> GetUserByEmail(string email, string password)
        {
            try {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    return BadRequest("Email and password are required.");
                var user = await _userService.GetUserByEmailAsync(email, password);
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
                _logger.LogInformation("User login Success");
                return Ok(userDto);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error retrieving user with email {Email}", email);
                return StatusCode(500, "An error occurred while processing your request.");
            }
               
        }
    }
}
