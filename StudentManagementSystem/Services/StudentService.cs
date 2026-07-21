using StudentManagementSystem.Common;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Repositories.IRepositories;
using StudentManagementSystem.Services.IService;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;
        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<ApiResponse<IEnumerable<StudentResponseDto>>> GetAllAsync(int page, int size)
        {
            List<Student> students = await _repository.GetAllAsync(page, size);

            if (!students.Any())
            {
                return ApiResponseHelper.NotFound<IEnumerable<StudentResponseDto>>(
                    message: "No record found.");
            }

            var result = students.Select(x => new StudentResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Course = x.Course,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            });

            _logger.LogInformation(
                "Fetched student list. Page: {Page}, Size: {Size}",
                page,
                size);

            return ApiResponseHelper.Success(
                result,
                "Students fetched successfully.");
        }
        public async Task<ApiResponse<StudentResponseDto>> CreateAsync(AddNewStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                IsDelete = false,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(student);

            var result = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email= student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };

            _logger.LogInformation("Student added successfully.");

            return ApiResponseHelper.Created(result, "Student added successfully.");
        }

        public async Task<ApiResponse<StudentResponseDto>> UpdateAsync(Guid id, UpdateStudentDto dto)
        {
            Student? student = await _repository.GetByIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Student not found. StudentId : {StudentId}", id);

                return ApiResponseHelper.NotFound<StudentResponseDto>(
                    message: "Student not found.");
            }

            student.Name = dto.Name;
            student.Age = dto.Age;
            student.Course = dto.Course;
            student.Email = dto.Email;
            student.UpdatedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(student);

            var result = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate,
                UpdatedDate = student.UpdatedDate
            };

            _logger.LogInformation("Student updated successfully.");

            return ApiResponseHelper.Success(result, "Student updated successfully.");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid studentId)
        {
            Student? product = await _repository.GetByIdAsync(studentId);

            if (product == null)
            {
                _logger.LogWarning("Student not found. StudentId : {studentId}", studentId);

                return ApiResponseHelper.NotFound<string>(
                    message: "Student not found.");
            }

            await _repository.SoftDeleteAsync(product);

            _logger.LogInformation("Student deleted successfully.");

            return ApiResponseHelper.Success<string>(
                "Student deleted successfully.",
                "Student deleted successfully.");
        }
    }
}
