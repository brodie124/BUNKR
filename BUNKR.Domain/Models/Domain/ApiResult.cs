using BUNKR.Domain.Enums;

namespace BUNKR.Domain.Models.Domain;

public class ApiResult : ApiResult<object>
{
    public static ApiResult Success() => new() { IsSuccess = true };
    
    public static ApiResult Failure(ErrorCode errorCode, string? errorMessage = null) => new()
    {
        IsSuccess = false,
        ErrorCode = errorCode,
        ErrorMessage = errorMessage
    };
    
    public static ApiResult FromServiceResult<T>(ServiceResult<T> serviceResult)
    {
        return new ApiResult
        {
            IsSuccess = serviceResult.IsSuccess,
            ErrorCode = serviceResult.ErrorCode,
            ErrorMessage = serviceResult.ErrorMessage
        };
    }
}

public class ApiResult<T>
{
    public static implicit operator ApiResult<T>(T? data) => Success(data);
    public static implicit operator ApiResult<T>(ServiceResult<T> serviceResult) => FromServiceResult(serviceResult);
    
    public required bool IsSuccess { get; init; }
    public T? Data { get; init; }
    public ErrorCode? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }

    public static ApiResult<T> Success(T? data = default) => new() { IsSuccess = true, Data = data };
    
    public static ApiResult<T> Failure(ErrorCode errorCode, string? errorMessage = null, T? data = default) => new()
    {
        IsSuccess = false,
        ErrorCode = errorCode,
        ErrorMessage = errorMessage,
        Data = data
    };

    public static ApiResult<T> FromServiceResult(ServiceResult<T> serviceResult)
    {
        return new ApiResult<T>
        {
            IsSuccess = serviceResult.IsSuccess,
            Data = serviceResult.Data,
            ErrorCode = serviceResult.ErrorCode,
            ErrorMessage = serviceResult.ErrorMessage
        };
    }
}