// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Infrastructure > JwtSettings.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

namespace BuberDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public const string Section = "JwtSettings";
    
    public string Secret { get; init; } = null!;

    public string Issuer { get; init; } = null!;

    public string Audience { get; init; } = null!;

    public int ExpiryInMinutes { get; init; }
}
