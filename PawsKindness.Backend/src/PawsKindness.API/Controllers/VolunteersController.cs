using Microsoft.AspNetCore.Mvc;
using PawsKindness.API.Extensions;
using PawsKindness.Application.Services.Volunteers.CreateVolunteer;

namespace PawsKindness.API.Controllers
{
    [Route("volunteers")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromServices] ICreateVolunteerService service,
            [FromBody] CreateVolunteerRequest request,
            CancellationToken cancellationToken)
        {
            var result = await service.ExecuteAsync(request, cancellationToken);

            return result.ToResponse();
        }
    }
}
