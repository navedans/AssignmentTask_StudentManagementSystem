using StudentManagementSystem.Entities;

namespace StudentManagementSystem.Repositories.IRepositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(int pageNumber, int pageSize);

        Task<Student?> GetByIdAsync(Guid id);

        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task SoftDeleteAsync(Student student);
    }
}
