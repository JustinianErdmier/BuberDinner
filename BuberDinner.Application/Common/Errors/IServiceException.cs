// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > IServiceException.cs
// Created: 17 11, 2022
// Modified: 17 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using System.Net;

namespace BuberDinner.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}
