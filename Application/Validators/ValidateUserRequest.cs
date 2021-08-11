using System;
using Application.Command;

using FluentValidation;

namespace Application.Validators
{
    public class ValidateUserRequest : AbstractValidator<RegistrateUserCommand>
    {
        public ValidateUserRequest()
        {
            RuleFor(x=> x.Password)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(x=> x.UserName)
                .NotEmpty()
                .MinimumLength(4);
        }
    }
}
