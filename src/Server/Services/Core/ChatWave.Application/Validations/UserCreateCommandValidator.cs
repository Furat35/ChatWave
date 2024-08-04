using ChatWave.Application.Features.Commands.Users;
using FluentValidation;

namespace ChatWave.Application.Validations
{
    public class UserCreateCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public UserCreateCommandValidator()
        {
            RuleFor(_ => _.Username).NotEmpty().WithMessage("Username can't be empty!");
            RuleFor(_ => _.PhoneNumber).NotEmpty().WithMessage("Phone number can't be empty!");
            RuleFor(_ => _.Email).NotEmpty().WithMessage("Email can't be empty!");
            RuleFor(_ => _.Password).NotEmpty().WithMessage("Password can't be empty!");
        }
    }
}
