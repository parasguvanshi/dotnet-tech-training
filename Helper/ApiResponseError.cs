namespace SportsManagementApp.Helper;

    public class ApiResponseError<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
       
    }

