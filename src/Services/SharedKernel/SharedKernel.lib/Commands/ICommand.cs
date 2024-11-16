using MediatR;

namespace SharedKernel.lib.Commands;
public interface ICommand<TResult> : IRequest<TResult> { }
