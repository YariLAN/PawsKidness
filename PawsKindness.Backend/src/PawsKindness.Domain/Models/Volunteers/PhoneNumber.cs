namespace PawsKindness.Domain.Models.Volunteers
{
    public record PhoneNumber
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static PhoneNumber Create(string value)
        {
            return new PhoneNumber(value);
        }
    }
}
