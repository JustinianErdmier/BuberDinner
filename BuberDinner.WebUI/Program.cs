using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddApplication();
}

WebApplication app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
