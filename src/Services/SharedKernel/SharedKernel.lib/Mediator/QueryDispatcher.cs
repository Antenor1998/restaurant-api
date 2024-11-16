using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharedKernel.lib.Queries;

namespace SharedKernel.lib.Mediator;

public class QueryDispatcher(IMediator mediator) {
    private readonly IMediator _mediator = mediator;

    public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> {
        return await _mediator.Send(query);
    }
}
