using cqrs.Application.User.Commands;
using FluentValidation;

namespace cqrs.Application.User.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email can not be null")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can not be null");
        }
    }
}
