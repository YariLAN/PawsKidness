namespace PawsKindness.Domain.Shared;

public class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var forName = name ?? "Value";

            return Error.Validation("value.is.invalid", $"\"{forName}\" is invalid");
        }

        public static Error ValueIsEmpty(string? name = null)
        {
            var forName = name ?? "Value";

            return Error.Validation("value.is.empty", $"{name} can not be empty.");
        }

        public static Error NotFound(Guid? id = null)
        {
            string forId = id is null
                ? ""
                : $": id = {id}";
                
            return Error.NotFound("record.not.found", $"Record not found{forId}");
        }

        public static Error ValueIsInvalidLength(string? name = null)
        {
            string forName = name is null
                ? " "
                : " " + name + " ";

            return Error.Validation("length.is.invalid", $"Invalid{forName}length");
        }
    }
}
