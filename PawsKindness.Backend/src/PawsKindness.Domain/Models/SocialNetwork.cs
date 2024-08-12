namespace PawsKindness.Domain.Models;

public class SocialNetwork
{
    public Guid Id { get; private set; }

    public string Url { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;
}
