using System.Reflection.Metadata;
using System.Numerics;
using System.Threading;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Dtos;
using feed.Models;
using Microsoft.Extensions.Options;

namespace feed.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _uow;

        public PostService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Post>> GetListOfAllPosts()
        {
            return await _uow.PostRepository.GetAllAsync(orderBy: x => x.CreatedAt, isDescending: true);
        }

        public async Task<List<PostDto>> GetPostsWithLikeCountAndLikedByUser(int? userId)
        {
            return await _uow.PostRepository.GetPostsWithLikeCountAndLikedByUser(userId);
        }

        public async Task<int> SendPost(SendPostDto model)
        {
            var newPost = new Post
            {
                Content = model.Content,
                CreatedAt = DateTime.Now
            };

            await _uow.PostRepository.AddAsync(newPost);
            await _uow.CommitAsync();

            return newPost.Id;
        }

        public async Task<bool> DeletePost(int postId)
        {
            var postToBeDeleted = await _uow.PostRepository.GetByIdAsync(postId);
            _uow.PostRepository.Delete(postToBeDeleted);

            await _uow.CommitAsync();

            return true;
        }

        public async Task<int> LikePost(int userId, int postId)
        {
            var user = await _uow.UserRepository.GetByIdAsync(userId);
            var post = await _uow.PostRepository.GetByIdAsync(postId);

            if (user is null && post is null) return -1;

            #region If exists a like record in the table, delete it, else add new like record
            var like = await _uow.PostLikeRepository.FirstOrDefaultAsync(
                pl => pl.UserId == user.Id && pl.PostId == postId);

            if (like is not null)
            {
                _uow.PostLikeRepository.Delete(like);
            }
            else
            {
                var likePost = new PostLike
                {
                    UserId = userId,
                    PostId = postId
                };

                await _uow.PostLikeRepository.AddAsync(likePost);
            }
            #endregion

            return await _uow.CommitAsync();
        }
    }
}