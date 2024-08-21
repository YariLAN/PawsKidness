using CSharpFunctionalExtensions;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Domain.Models.PetControl.ValueObjects;

public record SocialNetwork
{
    public string Url { get; }

    public string Name { get; }

    private SocialNetwork() { }

    private SocialNetwork(string url, string name)
    {
        Url = url;
        Name = name;
    }

    public static Result<SocialNetwork, Error> Create(string url, string name)
    {
        if (string.IsNullOrWhiteSpace(url))
            return Errors.General.ValueIsEmpty(nameof(Url));

        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsEmpty(nameof(Name));

        if (name.Length > Constants.LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalidLength(nameof(Name));

        return new SocialNetwork(url, name);
    }
}
