using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Api.Dto;

namespace TelepathyLabs.ShowReels.Api.Validator
{
    public class VideoClipRequesValidator : AbstractValidator<VideoClipRequestDto>
    {
        public VideoClipRequesValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithMessage("Name cannot be null or empty.");

            RuleFor(x => x.Description)
                .NotNull().NotEmpty()
                .WithMessage("Description cannot be null or empty.");

            RuleFor(x => x.StartTimeCode)
                .NotNull()
                .SetValidator(new TimeCodeRequestValidator())
                .WithMessage("Start timecode cannot be null.");

            RuleFor(x => x.EndTimeCode)
                .NotNull()
                .SetValidator(new TimeCodeRequestValidator())
                .WithMessage("End timecode cannot be null.");
        }
    }
}
