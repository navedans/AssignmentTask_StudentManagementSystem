using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using StudentManagementSystem.Common;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Services.IService;

namespace StudentManagementSystem.Services
{
    public class AuthService: IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        public AuthService(IConfiguration configuration, ILogger<AuthenticationService> logger, JwtTokenGenerator jwtTokenGenerator)
        {
            _configuration = configuration;
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto)
        {
           
            var userName = _configuration["AuthUser:Username"];
            var password = _configuration["AuthUser:Password"];

            if (dto.UserName != userName || dto.Password != password)
            {
                return ApiResponseHelper.BadRequest<LoginResponseDto>(
                    message: "Invalid username or password.");
            }

            _logger.LogInformation("Generating JWT token for user {Username}.", dto.UserName);
            var token = _jwtTokenGenerator.GenerateToken(dto);
            _logger.LogInformation("JWT token generated successfully for {Username}.", dto.UserName);

            var response = new LoginResponseDto
            {
                Token = token
            };
            _logger.LogInformation("{Username} logged in successfully.", dto.UserName);

            return ApiResponseHelper.Success(
                response,
                "Login successful.");
        }
    }
}
