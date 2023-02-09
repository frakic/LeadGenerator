using BitMouse.LeadGenerator.Infrastructure.Domain;
using System.Net;

namespace BitMouse.LeadGenerator.Infrastructure.AspNetCore.Middleware.Error;

public class BusinessExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception e)
    {
        return e is BusinessException;
    }

    public ErrorDetails Handle(Exception e)
    {
        var businessException = e as BusinessException;

        var errorDetails = new BusinessErrorDetails("Business error occured",
            HttpStatusCode.BadRequest,
            businessException!.Code,
            businessException.Message,
            businessException.Parameter);

        return errorDetails;
    }
}
