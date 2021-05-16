using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardForm.DataAccess.Interface;
using CreditCardForm.Model;
using MongoDB.Driver;

namespace CreditCardForm.DataAccess.Concrete
{
    public class CreditCardFormRepository : ICreditCardFormRepository
    {
        private readonly IMongoCollection<CreditCard> _creditCards;

        public CreditCardFormRepository(ICreditCardFormDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _creditCards = database.GetCollection<CreditCard>(settings.CollectionName);
        }

        public async Task<CreditCard> Insert(CreditCard card)
        {
            await _creditCards.InsertOneAsync(card);
            return card;
        }

        public async Task<CreditCard> Get(Guid id)
        {
            var creditCards = await _creditCards.Find<CreditCard>(creditCard => creditCard.Id == id)
                .FirstOrDefaultAsync();
            return creditCards;
        }

        public async Task<IList<CreditCard>> GetAll()
        {
            var creditCards = await _creditCards.Find(creditCard => true).ToListAsync();
            return creditCards;
        }
    }
}