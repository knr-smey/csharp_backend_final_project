using System;
using System.Collections.Generic;

namespace final_project.Models
{
    public class Course
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public string CourseName { get; set; }

        public string Des { get; set; }

        public float Price { get; set; }

        public string Thumbnail { get; set; }

        public int CreatedBy { get; set; }

        public User? CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<CourseAttachment>? CourseAttachments { get; set; }
    }
}