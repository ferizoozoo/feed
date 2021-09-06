using System.Threading.Tasks;
using feed.Dtos;
using feed.Models;

namespace feed.Services
{
    public interface IUserService
    {
        Task<int> Register(RegisterUserDto registerUserModel);
        string Authenticate(LoginUserDto loginUserModel);
        Task<User> GetById(int userId);
    }
}