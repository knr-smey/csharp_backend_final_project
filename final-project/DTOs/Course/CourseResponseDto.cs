using System;

namespace final_project.DTOs.Course
{
    public class CourseResponseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string Des { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Thumbnail { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
