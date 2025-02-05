using FluentValidation;
using MoodApp.API.DTOs;

namespace MoodApp.API.Validators
{
    public class CreateMoodEntryDtoValidator : AbstractValidator<CreateMoodEntryDto>
    {
        public CreateMoodEntryDtoValidator()
        {
            RuleFor(x => x.MoodType)
                .IsInEnum().WithMessage("Invalid mood type");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("Note must not exceed 500 characters");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Invalid latitude value");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Invalid longitude value");
        }
    }

    public class UpdateMoodEntryDtoValidator : AbstractValidator<UpdateMoodEntryDto>
    {
        public UpdateMoodEntryDtoValidator()
        {
            RuleFor(x => x.MoodType)
                .IsInEnum().WithMessage("Invalid mood type");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("Note must not exceed 500 characters");
        }
    }
} 