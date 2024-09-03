using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PawsKindness.API.Response;
using PawsKindness.Domain.Shared;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace PawsKindness.API.Extensions;

public class CustomValidationResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(
        ActionExecutingContext context, 
        ValidationProblemDetails? validationProblemDetails)
    {
        if (validationProblemDetails is null)
        {
            throw new InvalidOperationException("ValidationProblemDetails is null");
        }

        List<ResponseError> errorResponses = [];
        
        foreach (var (propertyName, errors) in validationProblemDetails.Errors)
        {
            foreach (var error in errors)
            {
                var errorDeserialize = Error.Deserialize(error);

                errorResponses.Add(new(errorDeserialize.Code, errorDeserialize.Message, propertyName));
            };
        }
        
        return errorResponses.ToValidationResponse();
    }
}
