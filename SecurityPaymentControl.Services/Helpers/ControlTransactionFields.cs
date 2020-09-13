using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Helpers
{
    public class ControlTransactionFields
    {
        public DateTime TransactionDate { get; set; }
        public string UserTransaction { get; set; }
        public string ComputerName { get; set; }
    }
}
