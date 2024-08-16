namespace PawsKindness.Domain.Models.Volunteers;

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

    public static SocialNetwork Create(string url, string name)
    {
        return new SocialNetwork(url, name);
    }
}
