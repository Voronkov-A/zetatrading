using ZetaTrading.Adapters.WebApi.Common;
using ZetaTrading.Application.Journal;

namespace ZetaTrading.Adapters.WebApi.ErrorHandling;

public static class ExceptionRecordExtensions
{
    public static ErrorModel ToErrorModel(this ExceptionRecord exceptionRecord)
    {
        return new ErrorModel
        {
            Id = exceptionRecord.Id.ToString(),
            Type = exceptionRecord.Type,
            Data = new ErrorData
            {
                Message = exceptionRecord.Message
            }
        };
    }
}