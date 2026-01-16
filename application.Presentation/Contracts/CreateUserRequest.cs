namespace application.Presentation.Contracts
{
    public sealed record CreateUserRequest(
    string Email,
    string Name
);
}
