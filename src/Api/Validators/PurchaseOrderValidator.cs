using Contracts;
using FluentValidation;

namespace Api.Validators;

public class PurchaseOrderValidator : AbstractValidator<PurchaseOrder>
{
    public PurchaseOrderValidator()
    {
        RuleFor(p => p.Products).NotEmpty().When(m => !m.Memberships.Any())
            .WithMessage("Either membership or product must be provided");
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id must be provided");
    }
}