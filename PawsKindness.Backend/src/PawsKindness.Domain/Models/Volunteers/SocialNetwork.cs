namespace PawsKindness.Domain.Models.Volunteers;

public class SocialNetwork
{
    public SocialNetwork(string url, string name)
    {
        Url = url;
        Name = name;
    }

    public string Url { get; }

    public string Name { get; }
}
