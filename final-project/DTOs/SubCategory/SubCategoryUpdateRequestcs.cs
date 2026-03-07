namespace final_project.DTOs.SubCategory
{
    public class SubCategoryResponse
    {
        public int Id { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}