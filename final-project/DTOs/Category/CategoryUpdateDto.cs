using System.ComponentModel.DataAnnotations;

namespace final_project.DTOs.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
