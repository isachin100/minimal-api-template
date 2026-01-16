using MediatR;

namespace application.application.Abstractions.Messaging
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
