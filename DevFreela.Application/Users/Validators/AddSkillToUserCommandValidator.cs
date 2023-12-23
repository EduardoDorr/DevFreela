using FluentValidation;

using DevFreela.Application.Users.Commands;

namespace DevFreela.Application.Users.Validators;

public class AddSkillToUserCommandValidator : AbstractValidator<AddSkillToUserCommand>
{
    public AddSkillToUserCommandValidator()
    {
        RuleFor(r => r.UserId)
            .NotNull().WithMessage("UserId is required")
            .GreaterThan(0).WithMessage("UserId is not valid");

        RuleFor(r => r.SkillId)
            .NotNull().WithMessage("SkillId is required")
            .GreaterThan(0).WithMessage("SkillId is not valid");
    }
}