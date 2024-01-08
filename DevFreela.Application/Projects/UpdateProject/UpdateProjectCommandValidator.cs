using FluentValidation;

namespace DevFreela.Application.Projects.UpdateProject;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull().WithMessage("Title is required")
            .NotEmpty().WithMessage("Title must not be empty")
            .MinimumLength(5).WithMessage("Title must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("Title must have a maximum of 50 characters");

        RuleFor(r => r.Description)
            .NotNull().WithMessage("Description is required")
            .NotEmpty().WithMessage("Description must not be empty")
            .MinimumLength(5).WithMessage("Description must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("Description must have a maximum of 50 characters");

        RuleFor(r => r.TotalCost)
            .NotNull().WithMessage("TotalCost is required")
            .GreaterThan(0).WithMessage("TotalCost is not valid");
    }
}