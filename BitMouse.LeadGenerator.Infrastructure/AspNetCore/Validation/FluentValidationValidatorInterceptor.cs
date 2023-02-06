using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BitMouse.LeadGenerator.Infrastructure.AspNetCore.Validation;

public class FluentValidationValidatorInterceptor : IValidatorInterceptor
{
    public ValidationResult AfterAspNetValidation(ActionContext actionContext,
        IValidationContext validationContext,
        ValidationResult result)
    {
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        return result;
    }

    public IValidationContext BeforeAspNetValidation(ActionContext actionContext,
        IValidationContext commonContext)
    {
        return commonContext;
    }
}
