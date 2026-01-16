using MediatR;

namespace application.application.Abstractions.Messaging
{
    public interface ICommandHandler<TRequest, TResult>
       : IRequestHandler<TRequest, TResult>
       where TRequest : IRequest<TResult>
    {
    }
}
