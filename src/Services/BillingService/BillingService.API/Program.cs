using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using SharedKernel.lib.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura la dirección de escucha explícitamente
builder.WebHost.UseUrls("http://localhost:5002");

// Configura Consul
builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg => {
	cfg.Address = new Uri("http://127.0.0.1:8500");
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


var consulClient = app.Services.GetRequiredService<IConsulClient>();
var server       = app.Services.GetRequiredService<IServer>();
var lifetime     = app.Services.GetRequiredService<IHostApplicationLifetime>();

app.Services.GetRequiredService<IHostApplicationLifetime>()
	.ApplicationStarted.Register(() => {
		var consulHostedService = new ConsulHostedService(consulClient, server, lifetime, "BillingService", 5002);
		consulHostedService.StartAsync(default).GetAwaiter().GetResult();
	});

// Agrega servicios y middlewares
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
