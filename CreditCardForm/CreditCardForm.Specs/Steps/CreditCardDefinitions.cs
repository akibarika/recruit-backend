using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CreditCardForm.Model;
using FluentAssertions;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace CreditCardForm.Specs.Steps
{
    [Binding]
    public sealed class CreditCardDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IList<CreditCard> _cards;

        public CreditCardDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("cards pre-loaded")]
#pragma warning disable 1998
        public async Task CardPreloaded()
#pragma warning restore 1998
        {
            //Cards preloaded in Mongo DB
        }

        [When("get all cards")]
        public async Task GetAllCards()
        {
            using(HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync("https://localhost:44326/api/credit-card-form");
                _cards = JsonConvert.DeserializeObject<IList<CreditCard>>(await result.Content.ReadAsStringAsync());
            }
        }

        [Then("should have (.*) cards")]
        public async Task ThenShouldHaveXCards(int numberOfCards)
        {
            //TODO: implement assert (verification) logic

            await Task.Run(() =>
            {
                _cards.Should().NotBeNullOrEmpty();
                _cards.Should().HaveCount(numberOfCards);
            });
        }
    }
}