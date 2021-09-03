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
    public class PostController : ControllerBase
    {
        private readonly FeedDbContext _context;

        public PostController(FeedDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfAllPosts()
        {
            return Ok(await _context.Posts.OrderByDescending(x => x.CreatedAt).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SendPost(SendPostDto model)
        {
            var newPost = new Post
            {
                Content = model.Content,
                CreatedAt = DateTime.Now
            };

            try
            {
                await _context.Posts.AddAsync(newPost);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(newPost.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int postId)
        {
            try
            {
                var postToBeDeleted = await _context.Posts.FindAsync(postId);
                _context.Posts.Remove(postToBeDeleted);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(true);
        }
    }
}
