using System.Net;

namespace BitMouse.LeadGenerator.Infrastructure.AspNetCore.Middleware.Error;

public class ValidationErrorDetails : ErrorDetails
{
    public ICollection<ValidationError> Errors { get; private set; }

    public ValidationErrorDetails(string title,
        HttpStatusCode httpStatusCode,
        ICollection<ValidationError> errors)
        : base(title, httpStatusCode)
    {
        Errors = errors;
    }
}
