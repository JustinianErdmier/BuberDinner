// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > ErrorHandlingMiddleware.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using System.Net;
using System.Text.Json;

namespace BuberDinner.WebUI.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    // ReSharper disable once UnusedParameter.Local
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        const HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected

        string result = JsonSerializer.Serialize(new { error = "An error occured while processing your request." });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode  = (int) code;

        await context.Response.WriteAsync(result);
    }
}
