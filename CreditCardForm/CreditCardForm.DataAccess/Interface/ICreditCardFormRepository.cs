using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardForm.Model;

namespace CreditCardForm.DataAccess.Interface
{
    public interface ICreditCardFormRepository
    {
        Task<IList<CreditCard>> GetAll();
        Task<CreditCard> Get(Guid id);
        Task<CreditCard> Insert(CreditCard card);
        Task<CreditCard> GetByCardNumber(string number);
    }
}