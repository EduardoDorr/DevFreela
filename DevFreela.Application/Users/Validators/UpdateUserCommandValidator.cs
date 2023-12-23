using FluentValidation;

using DevFreela.Application.Users.Commands;

namespace DevFreela.Application.Users.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name must not be empty")
            .MinimumLength(5).WithMessage("Name must have a minimum of 5 characters")
            .MaximumLength(100).WithMessage("Name must have a maximum of 100 characters");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email is not valid")
            .MinimumLength(3).WithMessage("Email must have a minimum of 3 characters")
            .MaximumLength(80).WithMessage("Email must have a maximum of 80 characters");

        RuleFor(r => r.BirthDate)
            .NotNull().WithMessage("BirthDate is required")
            .NotEmpty().WithMessage("BirthDate must not be null or empty");
    }
}