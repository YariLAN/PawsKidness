using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PawsKindness.API.Extensions;
using PawsKindness.Application.Services.Volunteers.CreateVolunteer;
using PawsKindness.Domain.Shared;

namespace PawsKindness.API.Controllers
{
    [Route("volunteers")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromServices] ICreateVolunteerService service,
            [FromServices] IValidator<CreateVolunteerRequest> validator,
            [FromBody] CreateVolunteerRequest request,
            CancellationToken cancellationToken)
        {
            var validateResult = await validator.ValidateAsync(request, opt => opt.IncludeAllRuleSets(), cancellationToken);

            if (!validateResult.IsValid)
            {
                var res = validateResult.Errors.First();

                var error = Error.Validation(res.ErrorCode, res.ErrorMessage);

                return error.ToResponse();
            }

            var result = await service.ExecuteAsync(request, cancellationToken);

            return result.ToResponse();
        }
    }
}
