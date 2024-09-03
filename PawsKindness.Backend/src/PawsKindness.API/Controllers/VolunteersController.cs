using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PawsKindness.API.Extensions;
using PawsKindness.API.Response;
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
            var result = await service.ExecuteAsync(request, cancellationToken);

            return result.ToResponse();
        }
    }
}
