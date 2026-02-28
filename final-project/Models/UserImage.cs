using System;

namespace final_project.Models
{
    public class UserImage
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Path { get; set; }
        public string MimeType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}