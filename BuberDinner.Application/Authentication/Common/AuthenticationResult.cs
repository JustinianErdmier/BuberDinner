// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > AuthenticationResult.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
