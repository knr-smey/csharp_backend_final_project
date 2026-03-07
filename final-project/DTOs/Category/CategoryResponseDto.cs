using System;

namespace final_project.DTOs.Category
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
