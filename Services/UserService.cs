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
        private readonly IJwtService _jwtService;

        public UserService(FeedDbContext context, IConfiguration config, IJwtService jwtService)
        {
            _context = context;
            _config = config;
            _jwtService = jwtService;
        }

        public string Authenticate(LoginUserDto loginUserModel)
        {
            var hashedPassword = Crypto.GenerateSha256HashOfString(loginUserModel.Password);

            var user = _context.Users.Where(x => x.Username == loginUserModel.Username && x.Password == hashedPassword).FirstOrDefault();

            if (user is null)
                return null;

            user.LastLogin = DateTime.Now;
            _context.Users.Update(user);

            _context.SaveChanges();    

            return _jwtService.GenerateToken(user.Id);
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