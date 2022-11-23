// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > RegisterCommand.cs
// Created: 23 11, 2022
// Modified: 23 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Authentication.Common;

using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
