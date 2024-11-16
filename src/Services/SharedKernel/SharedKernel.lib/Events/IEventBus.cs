using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedKernel.lib.Events;

public interface IEventBus
{
	Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken = default);
	Task ConnectAsync();
	Task DisposeAsync();
}
