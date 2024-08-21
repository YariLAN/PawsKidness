using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.PetControl.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static Result<PhoneNumber, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Errors.General.ValueIsEmpty(nameof(PhoneNumber));

            if (value.Length > Constants.MIN_LOW_TEXT_LENGTH)
                return Errors.General.ValueIsInvalidLength(nameof(PhoneNumber));

            return new PhoneNumber(value);
        }
    }
}
