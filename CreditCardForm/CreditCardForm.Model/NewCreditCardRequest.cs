using System;

namespace CreditCardForm.Model
{
    public class NewCreditCardRequest : CreditCard
    {
        public DateTime WhenAdded { get; set; }
    }
}