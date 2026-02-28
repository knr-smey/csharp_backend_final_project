using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace final_project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<UserImage> UserImages { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}