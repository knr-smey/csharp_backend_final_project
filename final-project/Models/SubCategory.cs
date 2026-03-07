using System;

namespace final_project.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string SubCategoryName { get; set; }

        public int CreatedBy { get; set; }

        public User? CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}