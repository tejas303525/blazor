
using proj1.Server.Authentication;
using proj1.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proj1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // private readonly UserAccountService _userAccountService;
        private readonly userService _userService;

        public UserController(userService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserHardcodedAccount>> GetUser(string username)
        {
            var users = await _userService.GetUsers();
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user is null)
                return NotFound();
            else
                return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(UserHardcodedAccount user)
        {
            var users = await _userService.GetUsers();
            var existingUser = users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser is not null)
                return Conflict("Username already exists");
            await _userService.AddUser(user);
            return Ok();
        }


        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUser(string username, UserHardcodedAccount user)
        {
            var users = await _userService.GetUsers();
            var existingUser = users.FirstOrDefault(u => u.Username == username);
            if (existingUser is null)
                return NotFound();
            else
            {
                await _userService.UpdateUser(user);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await _userService.DeleteUser(id);
            if (users is null)
                return NotFound();
            else
            {
                return Ok();
            }
        }
    }
}