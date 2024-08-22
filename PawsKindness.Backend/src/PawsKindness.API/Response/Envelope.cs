using PawsKindness.Domain.Shared;

namespace PawsKindness.API.Response
{
    public record Envelope
    {
        public object? Body { get; }

        public string? ErrorCode { get; }

        public string? ErrorMessage { get; }

        public DateTime DateTimeCreated { get; }

        private Envelope(object? body, Error? error = null)
        {
            Body = body;
            ErrorCode = error?.Code;
            ErrorMessage = error?.Message;
            DateTimeCreated = DateTime.UtcNow;
        }

        public static Envelope Ok(object? body)
        {
            return new Envelope(body);
        }

        public static Envelope Error(Error error)
        {
            return new Envelope(null, error);
        }
    }
}
