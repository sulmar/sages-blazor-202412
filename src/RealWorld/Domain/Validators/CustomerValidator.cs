using Domain.Abstractions;
using Domain.Models;
using FluentValidation;

namespace Domain.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .MaximumLength(10)
            .MinimumLength(2)
            .WithName("Imię")
            .WithMessage("Niepoprawna wartość pola {PropertyName} ");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .MaximumLength(10)
            .MinimumLength(3);

        RuleFor(p => p.Password)
            .Equal(p => p.ConfirmPassword);

        RuleFor(p => p.Email)
            .Matches(@"^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$");

    }
}
