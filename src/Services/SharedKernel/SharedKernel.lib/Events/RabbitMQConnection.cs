using RabbitMQ.Client;

namespace SharedKernel.lib.Events;

public class RabbitMQConnection
{
	private readonly IConnection _connection;
	 private readonly ConnectionFactory _factory;
	public RabbitMQConnection(string hostName) {
		 _factory = new ConnectionFactory
            {
                HostName = hostName,
            };
	}

	public IModel CreateModel() => _connection.CreateModel();
}
