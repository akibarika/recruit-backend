using System;
using FluentValidation;

namespace CreditCardForm.Model
{
    public class CreditCardValidator : AbstractValidator<NewCreditCardRequestDto>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CardNumber).CreditCard().NotEmpty();
            RuleFor(x => x.CardHolder).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Cvv).Matches("^[0-9]{3}$").NotEmpty();
            RuleFor(x => x.ExpireDate).GreaterThanOrEqualTo(a => DateTime.Today);
        }
    }
}