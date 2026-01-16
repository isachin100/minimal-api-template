using MediatR;

namespace application.application.Abstractions.Messaging
{
    public interface IQueryHandler<TRequest, TResult>
        : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
    }
}
