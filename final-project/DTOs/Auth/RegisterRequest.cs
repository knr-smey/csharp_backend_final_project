using System.ComponentModel.DataAnnotations;

namespace final_project.DTOs
{
    public class RegisterRequest
    {
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Gender { get; set; }

        [MinLength(6)]
        public required string Password { get; set; }
    }
}