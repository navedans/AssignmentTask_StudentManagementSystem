namespace StudentManagementSystem.Common
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsError { get; set; }

        public T? Data { get; set; }
    }
}
