using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.WebUI;
using BuberDinner.WebUI.Common.Errors;

using Microsoft.AspNetCore.Mvc.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddWebUI()
           .AddApplication()
           .AddInfrastructure(builder.Configuration);
}

WebApplication app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
