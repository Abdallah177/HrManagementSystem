using HrManagementSystem.Common.Enums;

namespace HrManagementSystem.Common.Views
{
    public class EndpointResponse<T>(T Data, bool IsSuccess, string Message, ErrorCode ErrorCode)
    {
        public T Data { get; } = Data;
        public bool IsSuccess { get; } = IsSuccess;
        public string Message { get; } = Message;
        public ErrorCode ErrorCode { get; } = ErrorCode;

        public static EndpointResponse<T> Success(T data, string Message = "")
        {
            return new EndpointResponse<T>(data, true, Message, ErrorCode.NoError);
        }

        public static EndpointResponse<T> Failure(string Message = "", ErrorCode errorCode = ErrorCode.NoError)
        {
            return new EndpointResponse<T>(default, false, Message, errorCode);
        }

        public static EndpointResponse<T> Failure(ErrorCode errorCode)
        {
            return new EndpointResponse<T>(default, false, string.Empty, errorCode);
        }
    }
}
