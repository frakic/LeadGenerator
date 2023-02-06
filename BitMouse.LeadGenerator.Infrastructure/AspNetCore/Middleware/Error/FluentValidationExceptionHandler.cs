using FluentValidation;
using System.Net;

namespace BitMouse.LeadGenerator.Infrastructure.AspNetCore.Middleware.Error;

public class FluentValidationExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception e)
    {
        return e is ValidationException;
    }

    public ErrorDetails Handle(Exception e)
    {
        var validationException = e as ValidationException;
        var validationErrors = new List<ValidationError>();

        foreach (var error in validationException!.Errors)
        {
            var validationError = new ValidationError(
                propertyName: error.PropertyName,
                code: error.ErrorCode,
                message: error.ErrorMessage);

            validationErrors.Add(validationError);
        }

        var errorDetails = new ValidationErrorDetails(
            title: "One or more validation errors occured",
            httpStatusCode: HttpStatusCode.BadRequest,
            errors: validationErrors);

        return errorDetails;
    }
}
