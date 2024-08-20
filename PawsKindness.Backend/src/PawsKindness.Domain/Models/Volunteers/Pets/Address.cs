using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.Volunteers.Pets;

public record Address
{
    public string Country { get; }

    public string City { get; }

    public int PostCode { get; }

    public string Street { get; }

    public string HouseNumber { get; }

    public string Apartment { get; }

    private Address(string city, string country, int postCode, string street, string houseNumber, string apartment)
    {
        City = city;
        Country = country;
        PostCode = postCode;
        Street = street;
        HouseNumber = houseNumber;
        Apartment = apartment;
    }

    public static Result<Address, Error> Create(
        string city, string country, int postCode, string street, string houseNum, string apart)
    {
        if (string.IsNullOrWhiteSpace(city) || city.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(City));

        if (string.IsNullOrWhiteSpace(country) || country.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(Country));

        if (postCode == 0)
            return Errors.General.ValueIsInvalid(nameof(PostCode));

        if (street.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Street));

        if (houseNum.Length > Constants.MIN_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(HouseNumber));

        if (apart.Length > Constants.MIN_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Apartment));

        return new Address(city, country, postCode, street, houseNum, apart);
    }
}
