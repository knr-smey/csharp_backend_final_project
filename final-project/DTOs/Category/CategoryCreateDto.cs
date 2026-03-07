using System.ComponentModel.DataAnnotations;

namespace final_project.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
