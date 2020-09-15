using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Calendar
{
    [Route("api/payment-calendar")]
    [ApiController]
    public class PaymentCallendarController : ControllerBase
    {
        private readonly PaymentCalendarService _paymentCalendarService;
        public PaymentCallendarController(PaymentCalendarService paymentCalendarService)
        {
            _paymentCalendarService = paymentCalendarService;

        }

        [Route("get-payment-calendar-configuration")]
        [HttpGet]
        public async Task<IActionResult> GetPaymentCallendarConfiguration()
        {
            var message = await _paymentCalendarService.GetPaymentCallendarConfiguration();
            return Ok(message);
        }


        [Route("save-payment-calendar-configuration")]
        [HttpPost]
        public async Task<IActionResult> SavePaymentCalendarConfiguration([FromBody] PaymentCalendarRequest paymentCalendarRequest)
        {
            var message = await _paymentCalendarService.SavePaymentCalendarConfiguration(paymentCalendarRequest);
            return Ok(message);
        }
        
    }
}
