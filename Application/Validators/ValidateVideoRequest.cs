using System;
using Application.Command;
using FluentValidation;

namespace Application.Validators
{
    public class ValidateVideoRequest : AbstractValidator<CreateVideoCommand>
    {
        public ValidateVideoRequest()
        {
            RuleFor(x=> x.videoName)
                .MinimumLength(4)
                .MaximumLength(40);
        }
    }
}
