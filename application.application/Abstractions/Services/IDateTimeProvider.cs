namespace application.application.Abstractions.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
