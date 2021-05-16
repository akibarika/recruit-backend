using System;
using Xunit;
using Bogus;
using CreditCardForm.Model;

namespace CreditCardForm.UnitTests
{
    public class CreditCardFormServiceTests
    {
        [Fact]
        public void ShouldReturnValid()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvc, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenNoGuid()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Name, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvc, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenNoName()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvc, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenNoNumber()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, (f) => f.Name.FullName())
                .RuleFor(u => u.Cvc, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenNoCvv()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldReturnInValidWhenNoDate()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvc, f => f.Finance.CreditCardCvv());

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void ShouldReturnInValidWhenDateIsBefore()
        {
            var testCreditCard = new Faker<CreditCard>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, (f) => f.Name.FullName())
                .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
                .RuleFor(u => u.Cvc, f => f.Finance.CreditCardCvv())
                .RuleFor(u => u.ExpireDate, f => f.Date.Between(DateTime.Today.AddYears(-1),DateTime.Today));

            var creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.Validate(testCreditCard);
            Assert.False(result.IsValid);
        }
    }
}