using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace SharedKernel.lib.Messaging;

public class RabbitMQEventBus : IEventBus {
	private readonly ConnectionFactory _factory;
	private IConnection? _connection;
	private IChannel? _channel;


	public RabbitMQEventBus(string hostName, string userName, string password)	{
		_factory = new ConnectionFactory {
			HostName = hostName,
			UserName = userName,
			Password = password,
			Port = 5672,
		};
	}

	public async Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken = default) {
		if (_channel == null) {
			Console.WriteLine("[WARN] RabbitMQ channel is not created.");
			return;
		}

		var queueName = @event.GetType().Name;

		await _channel.QueueDeclareAsync(
			queue: queueName,
			durable: true,
			exclusive: false,
			autoDelete: false,
			arguments: null,
			cancellationToken: cancellationToken
		);

		var message = JsonSerializer.Serialize(@event);
		var body = Encoding.UTF8.GetBytes(message);

		// Crear propiedades básicas del mensaje
		var properties = new BasicProperties {
			ContentType = "application/json",
			DeliveryMode = DeliveryModes.Persistent
		};

		// Publicar el mensaje de forma asíncrona con las nuevas propiedades
		await _channel.BasicPublishAsync(
				exchange: "",
				routingKey: queueName,
				mandatory: false,
				basicProperties: properties,
				body: new ReadOnlyMemory<byte>(body),
				cancellationToken: cancellationToken
			);

		Console.WriteLine($"[x] Event Published: {queueName}");
	}

	public async Task ConnectAsync() {
		_connection = await _factory.CreateConnectionAsync();
		_channel = await _connection.CreateChannelAsync();
	}


	public async Task DisposeAsync() {
		if (_channel != null) {
			await _channel.CloseAsync();
			await _channel.DisposeAsync();
		}

		if (_connection != null) {
			await _connection.CloseAsync();
			await _connection.DisposeAsync();
		}

		Console.WriteLine("RabbitMQ connection closed.");
	}

}
