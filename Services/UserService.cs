using System.Text;
using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using feed.Infrastructure;
using feed.Dtos;
using feed.Utility;
using feed.Models;

namespace feed.Services
{
    public class UserService : IUserService
    {
        private readonly FeedDbContext _context;
        private readonly IConfiguration _config;

        public UserService(FeedDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private string GenerateToken(User user)
        {
            // TODO: use JwtTokenHandler and add claims to it, create token 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] 
                    {
                        new Claim("id", user.Id.ToString()),
                        new Claim("username", user.Username.ToString()),
                        new Claim("password", user.Password.ToString()),
                        new Claim("email", user.Email.ToString()),
                        new Claim("createdAt", user.CreatedAt.ToString()),
                        new Claim("lastLogin", user.LastLogin.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Authenticate(LoginUserDto loginUserModel)
        {
            var hashedPassword = Crypto.GenerateSha256HashOfString(loginUserModel.Password);

            var user = _context.Users.Where(x => x.Username == loginUserModel.Username && x.Password == hashedPassword).FirstOrDefault();

            if (user is null)
                return null;

            return GenerateToken(user);    
        }

        public async Task<int> Register(RegisterUserDto registerUserModel)
        {
            var newUser = new User
            {
                Username = registerUserModel.Username,
                Password = Crypto.GenerateSha256HashOfString(registerUserModel.Password),
                Email = registerUserModel.Email,
                CreatedAt = DateTime.Now,
            };

            await _context.Users.AddAsync(newUser);

            return await _context.SaveChangesAsync();
        }

        public async Task<User> GetById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}