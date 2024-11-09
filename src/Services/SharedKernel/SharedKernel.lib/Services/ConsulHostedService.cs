using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;

namespace SharedKernel.lib.Services;

public class ConsulHostedService : IHostedService {
	private readonly IConsulClient _consulClient;
	private readonly IServer _server;
	private readonly IHostApplicationLifetime _lifetime;
	private readonly string _serviceName;
	private readonly int _servicePort;
	private string _registrationId;

	public ConsulHostedService(IConsulClient consulClient, IServer server, IHostApplicationLifetime lifetime, string serviceName, int servicePort) {
		_consulClient = consulClient;
		_server = server;
		_lifetime = lifetime;
		_serviceName = serviceName;
		_servicePort = servicePort;
	}
	public async Task StartAsync(CancellationToken cancellationToken) {
		var features = _server.Features.Get<IServerAddressesFeature>();
		var address = (features?.Addresses.FirstOrDefault()) ?? throw new InvalidOperationException("No se pudo obtener una dirección para registrar el servicio en Consul.");

	    var uri = new Uri(address);
		_registrationId = $"{uri.Host}-{_servicePort}-{_serviceName}";

		var registration = new AgentServiceRegistration {
			ID = _registrationId,
			Name = _serviceName,
			Address = "127.0.0.1",
			Port = _servicePort,
			Tags = ["api"]
		};

		await _consulClient.Agent.ServiceRegister(registration, cancellationToken);

		_lifetime.ApplicationStopping.Register(async () => {
			await _consulClient.Agent.ServiceDeregister(_registrationId);
		});
	}

	public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
