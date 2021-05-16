using System;
using FluentValidation;

namespace CreditCardForm.Model
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CardNumber).CreditCard().NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Cvc).Matches("^[0-9]{3}$").NotEmpty();
            RuleFor(x => x.ExpireDate).GreaterThanOrEqualTo(a => DateTime.Today);
        }
    }
}