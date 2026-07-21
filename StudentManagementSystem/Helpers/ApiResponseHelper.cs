using StudentManagementSystem.Common;

namespace StudentManagementSystem.Helpers
{
    public class ApiResponseHelper
    {
        public static ApiResponse<T> Success<T>(T? data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = message,
                IsError = false,
                Data = data
            };
        }

        public static ApiResponse<T> Created<T>(T? data, string message = "Created Successfully")
        {
            return new ApiResponse<T>
            {
                StatusCode = StatusCodes.Status201Created,
                Message = message,
                IsError = false,
                Data = data
            };
        }

        public static ApiResponse<T> BadRequest<T>(string message, T? data = default)
        {
            return new ApiResponse<T>
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = message,
                IsError = true,
                Data = data
            };
        }

        public static ApiResponse<T> NotFound<T>(string message, T? data = default)
        {
            return new ApiResponse<T>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = message,
                IsError = true,
                Data = data
            };
        }

        public static ApiResponse<T> InternalServerError<T>(string message, T? data = default)
        {
            return new ApiResponse<T>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = message,
                IsError = true,
                Data = data
            };
        }
    }
}
