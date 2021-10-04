using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Dtos;
using feed.Models;

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
    }
}