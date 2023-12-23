using FluentValidation;

using DevFreela.Application.Projects.Commands;

namespace DevFreela.Application.Projects.Validators;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(r => r.Content)
            .NotNull().WithMessage("Title is required")
            .NotEmpty().WithMessage("Title must not be empty")
            .MinimumLength(5).WithMessage("Title must have a minimum of 5 characters")
            .MaximumLength(255).WithMessage("Title must have a maximum of 255 characters");

        RuleFor(r => r.UserId)
            .NotNull().WithMessage("UserId is required")
            .GreaterThan(0).WithMessage("UserId is not valid");

        RuleFor(r => r.ProjectId)
            .NotNull().WithMessage("ProjectId is required")
            .GreaterThan(0).WithMessage("ProjectId is not valid");
    }
}