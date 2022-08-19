using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurveyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateUserAsync(createUserDto));
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateAdminAsync(createUserDto));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
    }
}

