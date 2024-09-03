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

        RuleFor(c => c.FullName).MustBeValueObject(n => FullName.Create(n.Surname, n.Name, n.MiddleName));

        RuleFor(c => c.Description)
            .MaximumLength(Constants.MIN_LOW_TEXT_LENGTH)
            .WithError(General.ValueIsInvalidLength("Description"));

        RuleFor(c => c.Phone).MustBeValueObject(PhoneNumber.Create);

        RuleFor(c => c.YearsExperience)
            .GreaterThan(0)
            .WithError(General.ValueIsInvalidLength("YearsExperience"));

        RuleForEach(c => c.RequisiteDtos).MustBeValueObject(x => Requisite.Create(x.Name, x.Description));

        RuleForEach(c => c.SocialNetworkDtos).MustBeValueObject(x => SocialNetwork.Create(x.Url, x.Name));
    }
}
