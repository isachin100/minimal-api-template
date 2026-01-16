namespace application.application.Abstractions.Messaging
{
    public interface IEventHandler<in TEvent>
    {
        Task Handle(TEvent notification, CancellationToken cancellationToken);
    }
}
