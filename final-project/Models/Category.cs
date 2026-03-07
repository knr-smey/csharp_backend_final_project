using System;
using System.Collections.Generic;

namespace final_project.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int CreatedBy { get; set; }

        public User? CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}