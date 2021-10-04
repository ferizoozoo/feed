using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Dtos;
using feed.Models;

namespace feed.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetListOfAllPosts();
        Task<int> SendPost(SendPostDto model);
        Task<bool> DeletePost(int postId);
    }
}