using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using SharedKernel.lib.Messaging;
using SharedKernel.lib.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel().UseUrls("http://0.0.0.0:5001");
var consulAddress = Environment.GetEnvironmentVariable("CONSUL_ADDRESS") ?? "http://consul:8500";


builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg => {
	cfg.Address = new Uri(consulAddress);
}));
var eventBus = new RabbitMQEventBus("rabbitmq", "guest", "guest");
builder.Services.AddSingleton<IEventBus>(eventBus);

// builder.Services.AddHostedService<ConsulHostedService>(provider =>
// {
// 	var consulClient = provider.GetRequiredService<IConsulClient>();
// 	var server = provider.GetRequiredService<IServer>();
// 	var lifetime = provider.GetRequiredService<IHostApplicationLifetime>();
// 	return new ConsulHostedService(consulClient, server, lifetime, "TenantService", 5001);
// });

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
