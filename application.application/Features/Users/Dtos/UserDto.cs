namespace application.application.Features.Users.Dtos
{
    public sealed class UserDto
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Name { get; }

        public UserDto(Guid id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
        }
    }
}
