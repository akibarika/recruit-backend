using System;

namespace CreditCardForm.Model
{
    public class CreditCard
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string Cvc { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}