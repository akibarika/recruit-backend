using System;
using Xunit;
using Bogus;
using CreditCardForm.Model;

namespace CreditCardForm.UnitTests
{
    public class CreditCardFormValidationTests
    {
        [Fact]
        public void ShouldReturnValid()
        {
            var testCreditCard = new Faker<NewCreditCardRequestDto>()
                .StrictMode(false)
                .RuleFor(u => u.CardHolder, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvv, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInvalidWhenNoName()
        {
            var testCreditCard = new Faker<NewCreditCardRequestDto>()
                .StrictMode(false)
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvv, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInvalidWhenNoNumber()
        {
            var testCreditCard = new Faker<NewCreditCardRequestDto>()
                .StrictMode(false)
                .RuleFor(u => u.CardHolder, (f) => f.Name.FullName())
                .RuleFor(u => u.Cvv, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInvalidWhenNoCvv()
        {
            var testCreditCard = new Faker<NewCreditCardRequestDto>()
                .StrictMode(false)
                .RuleFor(u => u.CardHolder, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInvalidWhenNoDate()
        {
            var testCreditCard = new Faker<NewCreditCardRequestDto>()
                .StrictMode(false)
                .RuleFor(u => u.CardHolder, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvv, f => f.Finance.CreditCardCvv());

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInvalidWhenDateIsBefore()
        {
            var testCreditCard = new Faker<NewCreditCardRequestDto>()
                .StrictMode(false)
                .RuleFor(u => u.CardHolder, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvv, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today.AddYears(-1), DateTime.Today));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }
    }
}