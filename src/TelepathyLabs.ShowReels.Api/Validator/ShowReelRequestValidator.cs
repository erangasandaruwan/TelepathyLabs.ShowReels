using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using TelepathyLabs.ShowReels.Api.Dto;

namespace TelepathyLabs.ShowReels.Api.Validator
{
    public class ShowReelRequestValidator : AbstractValidator<ShowReelRequestDto>
    {
        public ShowReelRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithMessage("Name cannot be null or empty.");

            RuleFor(x => x.Description)
                .NotNull().NotEmpty()
                .WithMessage("Description cannot be null or empty.");

            RuleFor(x => x.VideoClips)
                .Must(x => x != null && x.Any())
                .WithMessage("Atleast on video clip is required.");

            RuleForEach(x => x.VideoClips)
                .SetValidator(new VideoClipRequesValidator());
        }
    }
}
