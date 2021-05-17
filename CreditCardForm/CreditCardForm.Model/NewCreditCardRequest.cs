using System;

namespace CreditCardForm.Model
{
    /// <summary>
    /// Data transfer object  
    /// </summary>
    public class NewCreditCardRequestDto
    {
        /// <summary>
        /// Credit Card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit Card holder
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        /// Credit card Cvv
        /// </summary>
        public string Cvv { get; set; }

        /// <summary>
        /// Credit card Expire Date
        /// </summary>
        public DateTime ExpireDate { get; set; }
    }
}