namespace Core.Helper
{
    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse()
        {

        }

        public ApiResponse(T data, bool isSuccess, int status, string message) : base(isSuccess, status, message)
        {
            Data = data;
        }
        public ApiResponse(bool isSuccess, int status, string message) : base(isSuccess, status, message)
        {
        }
        public static ApiResponse<T> ServerErrorResponse(string message)
        {
            return new ApiResponse<T>(false, 500, message);

        }
        public T Data { get; set; }


        public static ApiResponse<T> SuccessResponse(T data)
        {
            return new ApiResponse<T>(data, true, 200, String.Empty)

        ;
        }
        public static ApiResponse<T> ClientErrorResponse(string message)
        {
            return new ApiResponse<T>(false, 400, message);

        }
    }

    public class ApiResponse
    {
        public ApiResponse(bool isSuccess, int status, string message)
        {
            this.isSuccess = isSuccess;
            this.Status = status;
            this.Message = message;
        }
        public ApiResponse()
        {

        }
        public bool isSuccess { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public static ApiResponse ClientErrorResponse(string message)
        {
            return new ApiResponse()
            {
                isSuccess = false,
                Message = message,
                Status = 400
            };
        }
        public static ApiResponse ServerError(string message)
        {
            return new ApiResponse()
            {
                isSuccess = false,
                Message = message,
                Status = 500
            };
        }
        public static ApiResponse SuccessResponse(string message)
        {
            return new ApiResponse()
            {
                isSuccess = true,
                Message = message,
                Status = 200
            };
        }



    }

}
