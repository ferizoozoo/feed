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
using Microsoft.AspNetCore.Http;

namespace feed.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly FeedDbContext _context;

        public UserController(FeedDbContext context)
        {
            _context = context;
        }

        // [HttpPost]
        // public async Task<IActionResult> Register(RegisterUserDto registerUserModel)
        // {

        // }

        // [HttpPost]
        // public async Task<IActionResult> Login(LoginUserDto loginUserModel)
        // {
            
        // }

        // [HttpPost]
        // public async Task<IActionResult> Logout()
        // {
        //     return Ok();
        // }
    }
}
