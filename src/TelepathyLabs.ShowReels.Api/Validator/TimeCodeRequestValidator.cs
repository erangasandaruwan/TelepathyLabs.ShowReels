using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Api.Dto;

namespace TelepathyLabs.ShowReels.Api.Validator
{
    public class TimeCodeRequestValidator : AbstractValidator<TimeCodeRequestDto>
    {
        public TimeCodeRequestValidator()
        {
            RuleFor(x => x.Hours)
                .NotNull()
                .WithMessage("Hours cannot be null or empty.");

            RuleFor(x => x.Minutes)
                .NotNull().NotEmpty()
                .WithMessage("Minutes cannot be null or empty.");
            RuleFor(x => x.Minutes)
                .LessThan(60)
                .WithMessage("Minute should be less than 60.");

            RuleFor(x => x.Seconds)
                .NotNull()
                .WithMessage("Seconds cannot be null or empty.");
            RuleFor(x => x.Seconds)
                .GreaterThan(0)
                .WithMessage("Seconds cannot be less than zero.");
            RuleFor(x => x.Seconds)
                .LessThan(60)
                .WithMessage("Second should be less than 60.");

            RuleFor(x => x.Frames)
                .NotNull()
                .WithMessage("Frames cannot be null or empty.");
            RuleFor(x => x.Seconds)
                .LessThan(0)
                .WithMessage("Frames cannot be less than zero.");
        }
    }
}
