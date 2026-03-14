using System.ComponentModel.DataAnnotations;

namespace final_project.DTOs.Course
{
    public class CourseCreateDto
    {
        [Required]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        public string Des { get; set; } = string.Empty;

        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [Required]
        public string Thumbnail { get; set; } = string.Empty;
    }
}
