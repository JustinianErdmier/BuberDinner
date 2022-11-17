// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Domain > Errors.User.cs
// Created: 17 11, 2022
// Modified: 17 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "User with this email already exists");
    }
}
