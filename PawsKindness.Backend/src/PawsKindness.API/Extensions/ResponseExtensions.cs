using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PawsKindness.API.Response;
using PawsKindness.Domain.Enums;
using PawsKindness.Domain.Shared;

namespace PawsKindness.API.Extensions
{
    public static class ResponseExtensions
    {
        public static ActionResult<T> ToResponse<T>(this Result<T, Error> result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(Envelope.Ok(result.Value));
            }

            var statusCode = result.Error.Type switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Failure => StatusCodes.Status500InternalServerError,

                _ => StatusCodes.Status500InternalServerError,
            };

            return new ObjectResult(Envelope.Error(result.Error))
            {
                StatusCode = statusCode,
            };
        }
    }
}
