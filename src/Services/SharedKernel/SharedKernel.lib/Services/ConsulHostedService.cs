using System.Net;
using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;

namespace SharedKernel.lib.Services;

public class ConsulHostedService(IConsulClient consulClient,
								 IServer server,
								 IHostApplicationLifetime lifetime,
								 string serviceName,
								 int servicePort) : IHostedService {

	private readonly IServer _server = server;
	private string? _registrationId;

	public async Task StartAsync(CancellationToken cancellationToken) {
	 	var ipAddress = GetContainerIpAddress();
    	if (string.IsNullOrEmpty(ipAddress)) {
            throw new InvalidOperationException("No se pudo obtener la dirección IP del contenedor.");
        }

        Console.WriteLine($"[INFO] Registrando servicio en Consul en la dirección {ipAddress}");

        _registrationId = $"{serviceName}-{ipAddress}-{servicePort}";

		var registration = new AgentServiceRegistration {
		    ID = _registrationId,
            Name = serviceName,
            Address = ipAddress,
            Port = servicePort,
			Tags = ["api"]
		};

		await consulClient.Agent.ServiceRegister(registration, cancellationToken);

		lifetime.ApplicationStopping.Register(async () => {
			await consulClient.Agent.ServiceDeregister(_registrationId);
		});

		 Console.WriteLine($"Servicio registrado en Consul con ID {_registrationId}");
	}

	public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;


	/// <summary>
    /// Obtiene la dirección IP interna del contenedor.
    /// </summary>
    private static string? GetContainerIpAddress(){
        try {
            var hostName = Dns.GetHostName();
            var addresses = Dns.GetHostAddresses(hostName);
            return addresses.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString();
        }
        catch (Exception ex) {
            Console.WriteLine($"[ERROR] No se pudo obtener la dirección IP: {ex.Message}");
            return null;
        }
    }
}
