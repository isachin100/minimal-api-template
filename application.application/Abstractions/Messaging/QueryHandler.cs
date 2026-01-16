using MediatR;
using Microsoft.Extensions.Logging;

namespace application.application.Abstractions.Messaging
{
    public abstract class QueryHandler<TRequest, TResult>
    : IQueryHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
    {
        protected readonly ILogger Logger;

        protected QueryHandler(ILogger logger)
        {
            Logger = logger;
        }

        public abstract Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
