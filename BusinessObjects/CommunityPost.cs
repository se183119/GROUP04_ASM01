using System;

namespace BusinessObjects
{
    public enum PostType
    {
        General = 1,
        SuccessStory = 2,
        Question = 3,
        Achievement = 4,
        Experience = 5,
        Advice = 6
    }

    public partial class CommunityPost
    {
        public int CommunityPostId { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public PostType Type { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; } = true;

        public int LikesCount { get; set; } = 0;

        public int CommentsCount { get; set; } = 0;

        public virtual Customer Author { get; set; } = null!;
    }
}