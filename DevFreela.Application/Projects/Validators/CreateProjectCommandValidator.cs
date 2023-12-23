using FluentValidation;

using DevFreela.Application.Projects.Commands;

namespace DevFreela.Application.Projects.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
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

        RuleFor(r => r.ClientId)
            .NotNull().WithMessage("ClientId is required")
            .GreaterThan(0).WithMessage("ClientId is not valid");

        RuleFor(r => r.FreelancerId)
            .NotNull().WithMessage("FreelancerId is required")
            .GreaterThan(0).WithMessage("FreelancerId is not valid");

        RuleFor(r => r.TotalCost)
            .NotNull().WithMessage("TotalCost is required")
            .GreaterThan(0).WithMessage("TotalCost is not valid");
    }
}