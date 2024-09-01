using PawsKindness.Domain.Shared;

namespace PawsKindness.API.Response;

public record ResponseError(string? ErrorCode, string? ErrorMessage, string? PropertyName);


public record Envelope
{
    public object? Body { get; }

    public List<ResponseError> Errors { get; }

    public DateTime DateTimeCreated { get; }

    private Envelope(object? body, IEnumerable<ResponseError> errors)
    {
        Body = body;
        Errors = errors.ToList();
        DateTimeCreated = DateTime.UtcNow;
    }

    public static Envelope Ok(object? body)
    {
        return new Envelope(body, []);
    }

    public static Envelope Error(IEnumerable<ResponseError> errors)
    {
        return new Envelope(null, errors);
    }
}
