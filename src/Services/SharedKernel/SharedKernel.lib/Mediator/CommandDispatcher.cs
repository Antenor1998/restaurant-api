
using MediatR;
using SharedKernel.lib.Commands;

namespace SharedKernel.lib.Mediator;
public class CommandDispatcher(IMediator mediator) {
    private readonly IMediator _mediator = mediator;

    public async Task<CommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand<CommandResult> {
        return await _mediator.Send(command);
    }
}
