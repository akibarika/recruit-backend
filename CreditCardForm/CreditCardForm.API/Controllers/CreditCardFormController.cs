using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CreditCardForm.Model;
using CreditCardForm.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardForm.API.Controllers
{
    [ApiController]
    [Route("api/credit-card-form")]
    public class CreditCardFormController : ControllerBase
    {
        private readonly ICreditCardFormService _service;

        public CreditCardFormController(ICreditCardFormService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IList<CreditCard>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<CreditCard> Get(Guid id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewCard(NewCreditCardRequestDto request)
        {
            var validator = new CreditCardValidator();

            var results = validator.Validate(request);
            if (!results.IsValid)
            {
                var stringBuilder = new StringBuilder();
                foreach (var failure in results.Errors)
                {
                    stringBuilder.Append(
                        $"Property  {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage} \n");
                }

                return new BadRequestObjectResult(stringBuilder.ToString());
            }

            var creditCard = await _service.GetByCardNumber(request.CardNumber);
            if (creditCard != null)
            {
                return new BadRequestObjectResult("Credit card number is exist, please enter a new credit card number");
            }

            var card = new CreditCard()
            {
                Id = Guid.NewGuid(),
                CardNumber = request.CardNumber,
                Name = request.Name,
                Cvc = request.Cvc,
                ExpireDate = request.ExpireDate,
            };

            card = await _service.AddNewCreditCard(card);
            return new OkObjectResult(card);
        }
    }
}