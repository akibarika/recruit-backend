using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardForm.Model;


namespace CreditCardForm.Service.Interface
{
    public interface ICreditCardFormService
    {
        Task<IList<CreditCard>> GetAll();
        Task<CreditCard> Get(Guid id);
        Task<CreditCard> AddNewCreditCard(CreditCard card);
    }
}