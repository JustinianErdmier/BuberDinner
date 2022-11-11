// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > AuthenticationResult.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult(Guid Id, string FirstName, string LastName, string Email, string Token);
