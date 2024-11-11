using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using SharedKernel.lib.Messaging;
using SharedKernel.lib.Services;
using TenantService.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


builder.WebHost.UseKestrel().UseUrls("http://0.0.0.0:5001");
var consulAddress = Environment.GetEnvironmentVariable("CONSUL_ADDRESS") ?? "http://consul:8500";


builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg => {
	cfg.Address = new Uri(consulAddress);
}));

var eventBus = new RabbitMQEventBus("rabbitmq", "guest", "guest");
builder.Services.AddSingleton<IEventBus>(eventBus);

services.AddDbContext<TenantDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/health", () => "Healthy");

var consulClient = app.Services.GetRequiredService<IConsulClient>();
var server       = app.Services.GetRequiredService<IServer>();
var lifetime     = app.Services.GetRequiredService<IHostApplicationLifetime>();

app.Services.GetRequiredService<IHostApplicationLifetime>()
	.ApplicationStarted.Register(() => {
		var consulHostedService = new ConsulHostedService(consulClient, server, lifetime, "TenantService", 5001);
		consulHostedService.StartAsync(default).GetAwaiter().GetResult();
	});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
