using MediatR;

namespace application.application.Abstractions.Messaging
{
    public interface ICommand<out TResult> : IRequest<TResult> { }

    public interface ICommand : ICommand<Unit> { }
}
