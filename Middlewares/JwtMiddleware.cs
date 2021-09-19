using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using feed.Services;

namespace feed.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;

        public JwtMiddleware(RequestDelegate next, IConfiguration config, IJwtService jwtService)
        {
            _next = next;
            _config = config;
            _jwtService = jwtService;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token is not null)
            {
                var userClaims = _jwtService.GetClaims(token);
                var userId = int.Parse(userClaims.First(x => x.Type == "id").Value);

                context.Items["User"] = await userService.GetById(userId);
            }
            
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}