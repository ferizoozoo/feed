using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using feed.Infrastructure;
using Microsoft.EntityFrameworkCore;
using feed.Dtos;
using feed.Models;
using feed.Services;
using Microsoft.AspNetCore.Http;

namespace feed.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserModel)
        {
            return Ok(await _userService.Register(registerUserModel));
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto loginUserModel)
        {
            var token = _userService.Authenticate(loginUserModel);

            if (string.IsNullOrEmpty(token))
                return BadRequest();

            return Ok(token);    
        }
    }
}
