namespace SportsManagementApp.Helper;

    public class ApiResponseSuccess<T>
    {
        public string Message { get; set; } = null!;
        public T? Data { get; set; }
    }

