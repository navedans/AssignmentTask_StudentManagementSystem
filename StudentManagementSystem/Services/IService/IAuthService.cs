using StudentManagementSystem.Common;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.IService
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto);
    }
}
