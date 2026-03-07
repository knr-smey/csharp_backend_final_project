using System.ComponentModel.DataAnnotations;

namespace final_project.DTOs.SubCategory
{
    public class SubCategoryUpdateRequest
    {
        [Required]
        public string SubCategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}