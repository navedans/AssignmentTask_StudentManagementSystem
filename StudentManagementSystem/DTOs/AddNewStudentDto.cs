using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class AddNewStudentDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Course { get; set; } = string.Empty;
        [Range(0, int.MaxValue)]
        public int Age { get; set; }
    }
}
