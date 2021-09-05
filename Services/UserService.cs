using System;
using System.Linq;
using System.Threading.Tasks;
using feed.Infrastructure;
using feed.Dtos;
using feed.Utility;
using feed.Models;

namespace feed.Services
{
    public class UserService : IUserService
    {
        private readonly FeedDbContext _context;

        public UserService(FeedDbContext context)
        {
            _context = context;
        }

        // public string GenerateToken(User user)
        // {
        //     // TODO: use JwtTokenHandler and add claims to it, create token 
        // }

        // public async Task<int> Authenticate(LoginUserDto loginUserModel)
        // {
        //     var hashedPassword = Crypto.GenerateSha256HashOfString(loginUserModel.Password);

        //     var user = _context.Users.Where(x => x.Username == loginUserModel.Username && x.Password == hashedPassword).FirstOrDefault();

        //     if (user is null)
        //         return -1;
        // }

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
    }
}