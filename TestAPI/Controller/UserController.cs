using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controller
{
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("count")]
        public async Task<int> GetUsersCountAsync()
        {
            return await _userService.GetUsersCountAsync();
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<Users>>> GetUsersPaged(int pageNumber, int pageSize)
        {
            var result = await _userService.GetUsersPageAsync( pageNumber,  pageSize);
            return Ok(result);
        }
    }
}
