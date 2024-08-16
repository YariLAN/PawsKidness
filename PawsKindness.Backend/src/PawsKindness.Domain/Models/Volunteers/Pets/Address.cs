namespace PawsKindness.Domain.Models.Volunteers.Pets;

public record Address
{
    public string Country { get; }

    public string City { get; }

    public int PostCode { get; }

    public string Street { get; }

    public string HouseNumber { get; }

    public string Apartment { get; }

    protected Address(string city, string country, int postCode, string street, string houseNumber, string apartment)
    {
        City = city;
        Country = country;
        PostCode = postCode;
        Street = street;
        HouseNumber = houseNumber;
        Apartment = apartment;
    }
}
