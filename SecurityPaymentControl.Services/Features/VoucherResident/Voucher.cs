using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.VoucherResident
{
    public class Voucher :ControlTransactionFields
    {
        public int VoucherId { get; set; }
        public string ResidentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentCalendarDate { get; set; }
        public decimal PaymentAmmount{ get; set; }
        public decimal PendingAmmount { get; set; }

    }
}
