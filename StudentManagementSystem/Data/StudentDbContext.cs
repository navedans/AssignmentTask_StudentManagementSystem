using StudentManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
