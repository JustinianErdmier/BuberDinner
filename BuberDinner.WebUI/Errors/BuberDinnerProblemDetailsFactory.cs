// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > BuberDinnerProblemDetailsFactory.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace BuberDinner.WebUI.Errors;

public sealed class BuberDinnerProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public BuberDinnerProblemDetailsFactory(IOptions<ApiBehaviorOptions> options) => _options = options.Value ?? throw new ArgumentNullException(nameof(options));

    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null,
                                                        string?     instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status   = statusCode,
            Title    = title,
            Type     = type,
            Detail   = detail,
            Instance = instance,
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext,     ModelStateDictionary modelStateDictionary, int?    statusCode = null,
                                                                            string?     title    = null, string?              type = null,          string? detail     = null,
                                                                            string?     instance = null)
    {
        if (modelStateDictionary is null)
        {
            throw new ArgumentNullException(nameof(modelStateDictionary));
        }

        statusCode ??= 400;

        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode, Type = type, Detail = detail, Instance = instance,
        };

        if (title != null)
        {
            // For validation problem details, don't overwrite the default title with null.
            problemDetails.Title = title;
        }

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemDetailsDefaults(HttpContext? httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out ClientErrorData? clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type  ??= clientErrorData.Link;
        }

        string? traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;

        if (traceId is not null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        problemDetails.Extensions.Add("customProperty", "customValue");
    }
}
