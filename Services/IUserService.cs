using System.Threading.Tasks;
using feed.Dtos;

namespace feed.Services
{
    public interface IUserService
    {
        Task<int> Register(RegisterUserDto registerUserModel);
    }
}