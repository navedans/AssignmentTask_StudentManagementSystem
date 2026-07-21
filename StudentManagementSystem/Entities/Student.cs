using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Range(0, int.MaxValue)]
        public int Age { get; set; }
        public string Course { get; set; } = string.Empty;
        public bool IsDelete { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
