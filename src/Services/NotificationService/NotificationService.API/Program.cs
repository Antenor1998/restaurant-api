using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using SharedKernel.lib.Services;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.UseKestrel().UseUrls("http://localhost:5008");

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
		var consulHostedService = new ConsulHostedService(consulClient, server, lifetime, "NotificationService", 5008);
		consulHostedService.StartAsync(default).GetAwaiter().GetResult();
	});


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
