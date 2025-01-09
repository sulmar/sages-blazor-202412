using Domain.Models;
using FluentValidation;

namespace Domain.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p=>p.DicountedPrice)
            .GreaterThan(0)
            .When(p=>p.HasDiscount);
    }
}
