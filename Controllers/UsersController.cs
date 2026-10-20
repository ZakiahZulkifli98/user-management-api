using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using System.Net.Mail;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@techhive.com",
                Department = "IT"
            },
            new User
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Johnson",
                Email = "sarah.johnson@techhive.com",
                Department = "HR"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(users.AsReadOnly());
        }

       [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound(new
                    {
                        Message = $"User with ID {id} was not found."
                    });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

       [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
                return BadRequest("First name is required.");

            if (string.IsNullOrWhiteSpace(user.LastName))
                return BadRequest("Last name is required.");

            if (string.IsNullOrWhiteSpace(user.Email))
                return BadRequest("Email is required.");

            try
            {
                var email = new MailAddress(user.Email);
            }
            catch
            {
                return BadRequest("Invalid email format.");
            }

            if (users.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
                return BadRequest("Email already exists.");

            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;

            users.Add(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    Message = $"User with ID {id} was not found."
                });
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Department = updatedUser.Department;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    Message = $"User with ID {id} was not found."
                });
            }

            users.Remove(user);

            return NoContent();
        }
    }
}