using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel()
               .UseUrls("http://localhost:5001"); // Cambia el puerto según sea necesario

builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
{
    cfg.Address = new Uri("http://localhost:8500");
}));
builder.Services.AddControllers();
builder.Services.AddHostedService<ConsulHostedService>();

var app = builder.Build();

app.MapControllers();

app.Run();
