using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Dtos;
using feed.Utility;
using feed.Models;

namespace feed.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;

        public UserService(IUnitOfWork uow, IConfiguration config, IJwtService jwtService)
        {
            _uow = uow;
            _config = config;
            _jwtService = jwtService;
        }

        public string Authenticate(LoginUserDto loginUserModel)
        {
            var hashedPassword = Crypto.GenerateSha256HashOfString(loginUserModel.Password);

            var user = _uow.UserRepository.FirstOrDefault(x => x.Username == loginUserModel.Username && x.Password == hashedPassword);

            if (user is null)
                return null;

            user.LastLogin = DateTime.Now;
            _uow.UserRepository.Update(user);

            _uow.Commit();    

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

            await _uow.UserRepository.AddAsync(newUser);

            return await _uow.CommitAsync();
        }

        public async Task<User> GetById(int userId)
        {
            return await _uow.UserRepository.GetByIdAsync(userId);
        }
    }
}