namespace PawsKindness.Domain.Shared;

public class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var forName = name ?? "";

            return Error.Validation("value.is.invalid", $"Value \"{forName}\" is invalid");
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
