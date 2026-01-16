namespace application.application.Abstractions.Services
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        bool IsAuthenticated { get; }
    }
}
