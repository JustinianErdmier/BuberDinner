using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict("User.DuplicateEmail", "User with this email already exists");
    }
}
