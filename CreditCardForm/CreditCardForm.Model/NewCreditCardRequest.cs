using System;

namespace CreditCardForm.Model
{
    public class NewCreditCardRequestDto : CreditCard
    {
        public DateTime WhenAdded { get; set; }
    }
}