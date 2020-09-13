using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Invoice
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public int ResidentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentCalendarDate { get; set; }
        public decimal PaymentAmmount{ get; set; }
        public decimal PendingAmmount { get; set; }

    }
}
