using System;

namespace final_project.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        // Foreign Key for Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string SubCategoryName { get; set; }

        // Foreign Key for User (Essential to stop the Null error)
        public int UserId { get; set; }
        public User? User { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}