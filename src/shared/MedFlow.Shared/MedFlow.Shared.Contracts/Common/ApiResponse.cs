namespace MedFlow.Shared.Contracts.Common
{
    public record ApiResponse<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; }
        public T? Data { get; init; }

        public static ApiResponse<T> Ok(T? data, string message = "Success")
            => new()
            {
                Success = true,
                Message = message,
                Data = data
            };

        public static ApiResponse<T> Failed(string message)
            => new()
            {
                Success = false,
                Message = message
            };
    }
}
