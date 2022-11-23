// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > LoginQuery.cs
// Created: 23 11, 2022
// Modified: 23 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Authentication.Common;

using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
