using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardForm.DataAccess.Interface;
using CreditCardForm.Model;
using CreditCardForm.Service.Interface;

namespace CreditCardForm.Service.Concrete
{
    public class CreditCardFormService : ICreditCardFormService
    {
        private ICreditCardFormRepository _repo;

        public CreditCardFormService(ICreditCardFormRepository repo)
        {
            _repo = repo;
        }

        public async Task<CreditCard> AddNewCreditCard(CreditCard card)
        {
            var creditCard = await _repo.Insert(card);
            return creditCard;
        }

        public async Task<CreditCard> Get(Guid id)
        {
            var creditCard = await _repo.Get(id);
            return creditCard;
        }

        public async Task<IList<CreditCard>> GetAll()
        {
            var creditCards = await _repo.GetAll();
            return creditCards;
        }
    }
}