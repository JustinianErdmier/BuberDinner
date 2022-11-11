using BuberDinner.Application;
using BuberDinner.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddApplication()
           .AddInfrastructure(builder.Configuration);
}

WebApplication app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
