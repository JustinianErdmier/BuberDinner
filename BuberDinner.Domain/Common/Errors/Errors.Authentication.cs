// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Domain > Errors.Authentication.cs
// Created: 17 11, 2022
// Modified: 17 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(code: "Auth.InvalidCredentials", description: "Invalid credentials");
    }
}
