using System.ComponentModel.DataAnnotations;

namespace final_project.DTOs.Category
{
    public class CategoryCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
