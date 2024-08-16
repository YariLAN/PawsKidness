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

    public static Address Create(
        string city, string country, int postCode, string street, string houseNum, string apart)
    {
        return new(city, country, postCode, street, houseNum, apart);
    }
}
