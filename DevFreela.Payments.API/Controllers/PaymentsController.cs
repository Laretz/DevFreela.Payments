using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers
{
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymenteService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymenteService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentInfoInputModel paymentInfoInputModel)
        {
            var result = await _paymenteService.Process(paymentInfoInputModel);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}