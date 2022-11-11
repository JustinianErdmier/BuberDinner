// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Contracts > RegisterRequest.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

namespace BuberDinner.Contracts.Authentication;

public record RegisterRequest(string FirstName,
                              string LastName,
                              string Email,
                              string Password);
