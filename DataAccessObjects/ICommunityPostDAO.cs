using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public interface ICommunityPostDAO
    {
        List<CommunityPost> GetAllPosts();
        CommunityPost GetPostById(int postId);
        void CreatePost(CommunityPost post);
        void UpdatePost(CommunityPost post);
        void DeletePost(int postId);
        List<CommunityPost> GetPostsByAuthorId(int authorId);
        List<CommunityPost> GetPostsByType(PostType type);
        List<CommunityPost> GetActivePosts();
        List<CommunityPost> GetPostsByDateRange(DateTime startDate, DateTime endDate);
    }
}