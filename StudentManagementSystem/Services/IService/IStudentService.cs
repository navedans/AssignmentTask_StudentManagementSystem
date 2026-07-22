using StudentManagementSystem.Common;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.IService
{
    public interface IStudentService
    {
        Task<ApiResponse<IEnumerable<StudentResponseDto>>> GetAllAsync(int page, int size);

        Task<ApiResponse<StudentResponseDto>> CreateAsync(AddNewStudentDto dto);

        Task<ApiResponse<StudentResponseDto>> UpdateAsync(Guid id, UpdateStudentDto dto);

        Task<ApiResponse<string>> DeleteAsync(Guid productId);
        Task<ApiResponse<StudentResponseDto>> GetByIdAsync(Guid id);
    }
}
