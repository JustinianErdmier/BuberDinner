// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Contracts > AuthenticationResponse.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

namespace BuberDinner.Contracts.Authentication;

public record AuthenticationResponse(Guid   Id,
                                     string FirstName,
                                     string LastName,
                                     string Email,
                                     string Token);
