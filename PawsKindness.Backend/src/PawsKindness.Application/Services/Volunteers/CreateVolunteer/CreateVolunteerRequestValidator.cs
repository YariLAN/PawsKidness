using FluentValidation;
using PawsKindness.Application.Validation;
using PawsKindness.Domain.Models.PetControl.ValueObjects;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Volunteers;
using PawsKindness.Domain.Shared;
using System.Reflection.Metadata;
using static PawsKindness.Domain.Shared.Errors;

namespace PawsKindness.Application.Services.Volunteers.CreateVolunteer;

public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;

        RuleFor(x => new { x.Surname, x.Name, x.MiddleName }).MustBeValueObject(
            fn => FullName.Create(fn.Surname, fn.Name, fn.MiddleName));

        RuleFor(x => x.Description).MaximumLength(Constants.HIGH_TEXT_LENGTH);

        RuleFor(x => x.Phone).MustBeValueObject(PhoneNumber.Create);

        RuleFor(x => x.YearsExperience)
            .GreaterThan(0)
            .WithError(General.ValueIsInvalidLength("YearsExperience"));

        RuleForEach(x => x.RequisiteDtos).MustBeValueObject(x => Requisite.Create(x.Name, x.Description));

        RuleForEach(x => x.SocialNetworkDtos).MustBeValueObject(x => SocialNetwork.Create(x.Url, x.Name));
    }
}
