using HrManagementSystem.Common.Enums;

namespace HrManagementSystem.Common.Views
{
    public record RequestResult<T>(T Data , bool IsSuccess , string Message , ErrorCode ErrorCode)
    {
        public static RequestResult<T> Success(T data ,string Message="")
        {
            return new RequestResult<T> (data,true,Message, ErrorCode.NoError );
        }

        public static RequestResult<T> Failure(string Message = "" , ErrorCode errorCode = ErrorCode.NoError)
        {
            return new RequestResult<T>(default, true, Message, errorCode);
        }

        public static RequestResult<T> Failure(ErrorCode errorCode)
        {
            return new RequestResult<T>(default, true, string.Empty, errorCode);
        }
    }
}
