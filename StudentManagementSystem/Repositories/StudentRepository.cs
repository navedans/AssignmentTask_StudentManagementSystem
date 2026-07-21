using StudentManagementSystem.Data;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Students
                .AsNoTracking()
                .Where(x => !x.IsDelete)
                .OrderBy(x => x.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            student.UpdatedDate = DateTime.Now;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Student student)
        {
            student.IsDelete = true;
            student.UpdatedDate = DateTime.UtcNow;
            _context.Students.Update(student);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Student student)
        {
            
            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }
    }
}
