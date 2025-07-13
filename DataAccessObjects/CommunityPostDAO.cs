using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class CommunityPostDAO : ICommunityPostDAO
    {
        public void CreatePost(CommunityPost post)
        {
            using var context = new SmokingCessationContext();
            context.CommunityPosts.Add(post);
            context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            using var context = new SmokingCessationContext();
            var post = context.CommunityPosts.FirstOrDefault(x => x.CommunityPostId == postId);
            if (post != null)
            {
                post.IsActive = false;
                context.CommunityPosts.Update(post);
                context.SaveChanges();
            }
        }

        public List<CommunityPost> GetActivePosts()
        {
            using var context = new SmokingCessationContext();
            return context.CommunityPosts
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<CommunityPost> GetAllPosts()
        {
            using var context = new SmokingCessationContext();
            return context.CommunityPosts
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public CommunityPost GetPostById(int postId)
        {
            using var context = new SmokingCessationContext();
            return context.CommunityPosts.FirstOrDefault(x => x.CommunityPostId == postId);
        }

        public List<CommunityPost> GetPostsByAuthorId(int authorId)
        {
            using var context = new SmokingCessationContext();
            return context.CommunityPosts
                .Where(x => x.AuthorId == authorId && x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<CommunityPost> GetPostsByDateRange(DateTime startDate, DateTime endDate)
        {
            using var context = new SmokingCessationContext();
            return context.CommunityPosts
                .Where(x => x.CreatedDate >= startDate && 
                           x.CreatedDate <= endDate && 
                           x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public List<CommunityPost> GetPostsByType(PostType type)
        {
            using var context = new SmokingCessationContext();
            return context.CommunityPosts
                .Where(x => x.Type == type && x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }

        public void UpdatePost(CommunityPost post)
        {
            using var context = new SmokingCessationContext();
            post.ModifiedDate = DateTime.Now;
            context.CommunityPosts.Update(post);
            context.SaveChanges();
        }
    }
}