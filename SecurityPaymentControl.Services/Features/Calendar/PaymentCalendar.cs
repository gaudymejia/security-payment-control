using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Calendar
{
    public class PaymentCalendar:ControlTransactionFields
    {
        public int PaymentCalendarId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentCalendarAmmount { get; set; }


    }
}
