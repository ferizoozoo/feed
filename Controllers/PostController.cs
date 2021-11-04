using System.Net.Http;
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
using feed.Filters;
using feed.Services;
using Microsoft.AspNetCore.Http;

namespace feed.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfAllPosts()
        {
            return Ok(await _postService.GetListOfAllPosts());
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsWithLikeCountAndLikedByUser(int? userId)
        {
            return Ok(await _postService.GetPostsWithLikeCountAndLikedByUser(userId));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendPost(SendPostDto model)
        {
            try
            {
                return Ok(await _postService.SendPost(model));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int postId)
        {
            try
            {
                return Ok(await _postService.DeletePost(postId));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LikePost(PostLikingDto likeModel)
        {
            try
            {
                return Ok(await _postService.LikePost(likeModel.UserId, likeModel.PostId));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
