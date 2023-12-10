using BUNKR.Domain.Enums;

namespace BUNKR.Domain.Models.Domain;

public class ServiceResult<T>
{
    public static implicit operator ServiceResult<T>(T? data) => Success(data);
    
    public required bool IsSuccess { get; init; }
    public T? Data { get; init; }
    public ErrorCode? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
    public Exception? ErrorException { get; init; }

    public static ServiceResult<T> Success(T? data) => new() { IsSuccess = true, Data = data };

    public static ServiceResult<T> Failure(Exception ex, ErrorCode errorCode, string? errorMessage = null, T? data = default) => new()
        { 
            IsSuccess = false, 
            ErrorException = ex, 
            ErrorCode = errorCode, 
            ErrorMessage = errorMessage, 
            Data = data 
        };

    public static ServiceResult<T> Failure(ErrorCode errorCode, string? errorMessage = null, T? data = default) => new()
    {
        IsSuccess = false,
        ErrorCode = errorCode,
        ErrorMessage = errorMessage,
        Data = data
    };
}