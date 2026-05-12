using Microsoft.AspNetCore.Mvc;
using SmartUserManagement.Domain.Interfaces;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetActiveUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetActiveUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return Ok("User created successfully");

        }
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _userService.UpdateActiveUser(user);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteActiveUser(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
