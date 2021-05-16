using System;

namespace CreditCardForm.Model
{
    public class NewCreditCardRequestDto
    {
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string Cvc { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}