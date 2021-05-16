using System;

namespace CreditCardForm.Model
{
    public class CreditCard
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Credit Card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit Card holder
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Credit card CVC
        /// </summary>
        public string Cvc { get; set; }

        /// <summary>
        /// Credit card Expire Date
        /// </summary>
        public DateTime ExpireDate { get; set; }
    }
}