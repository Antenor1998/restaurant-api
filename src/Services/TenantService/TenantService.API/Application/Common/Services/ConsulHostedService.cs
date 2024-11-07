using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;

public class ConsulHostedService : IHostedService
{
	private readonly IConsulClient _consulClient;
	private readonly IServer _server;
	private readonly IHostApplicationLifetime _lifetime;
	private string _registrationId;

	public ConsulHostedService(IConsulClient consulClient, IServer server, IHostApplicationLifetime lifetime)
	{
		_consulClient = consulClient;
		_server = server;
		_lifetime = lifetime;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		// var features = _server.Features.Get<IServerAddressesFeature>();

		// if (features == null || !features.Addresses.Any())
		// {
		//     throw new InvalidOperationException("No se pudo obtener una dirección para registrar el servicio en Consul.");
		// }

		// var address = features.Addresses.First();
		// var uri = new Uri(address);
		  var uri = new Uri("http://localhost:5001");

		_registrationId = $"{uri.Host}-{uri.Port}-TenantService";

		var registration = new AgentServiceRegistration()
		{
			ID = _registrationId,
			Name = "TenantService",
		    Address = "127.0.0.1",
			Port = uri.Port,
			Tags = new[] { "api" }
		};

		await _consulClient.Agent.ServiceRegister(registration, cancellationToken);

		_lifetime.ApplicationStopping.Register(async () =>
		{
			await _consulClient.Agent.ServiceDeregister(_registrationId);
		});
	}

	public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
