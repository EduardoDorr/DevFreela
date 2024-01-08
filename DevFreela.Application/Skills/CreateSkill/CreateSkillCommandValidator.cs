using FluentValidation;

namespace DevFreela.Application.Skills.CreateSkill;

public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description is required")
            .NotEmpty().WithMessage("Description must not be empty")
            .MinimumLength(3).WithMessage("Description must have a minimum of 3 characters")
            .MaximumLength(50).WithMessage("Description must have a maximum of 50 characters");
    }
}