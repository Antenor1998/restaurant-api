using MediatR;

namespace SharedKernel.lib.Queries;
public interface IQuery<TResult> : IRequest<TResult> { }
