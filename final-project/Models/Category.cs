using System;
using System.Collections.Generic;

namespace final_project.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        // 1. Add this explicit Foreign Key property
        public int UserId { get; set; }

        public int CreatedBy { get; set; }

        // This is the navigation property
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}