using ErrorOr;

namespace DelightDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentiacation
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials.");
    }
}