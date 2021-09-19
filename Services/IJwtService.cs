using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Dtos;
using feed.Models;

namespace feed.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId);
        IEnumerable<Claim> GetClaims(string token);
    }
}