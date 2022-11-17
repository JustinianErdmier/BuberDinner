using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.WebUI.Errors;

// using BuberDinner.WebUI.Filters;
// using BuberDinner.WebUI.Middleware;
using Microsoft.AspNetCore.Mvc.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddApplication()
           .AddInfrastructure(builder.Configuration);

    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

WebApplication app = builder.Build();

{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    // app.Map("/error", (HttpContext httpContext) =>
    // {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //
    //     return Results.Problem();
    // });

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
