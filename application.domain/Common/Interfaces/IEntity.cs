namespace application.domain.Common.Interfaces
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
