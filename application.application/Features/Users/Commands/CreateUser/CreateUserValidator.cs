using FluentValidation;

namespace application.application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserValidator
        : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
