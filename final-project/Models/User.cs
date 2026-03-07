using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Gender { get; set; }
        public required string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserImage> UserImages { get; set; } = new List<UserImage>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}