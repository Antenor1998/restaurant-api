using MediatR;

namespace SharedKernel.lib.Commands;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult>
	where TCommand : ICommand<CommandResult> {
}
