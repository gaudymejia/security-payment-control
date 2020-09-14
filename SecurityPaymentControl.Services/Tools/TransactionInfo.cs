using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Tools
{
    public static class TransactionInfo
    {
        public static ControlTransactionFields GetTransactionInfo()
        {
            return new ControlTransactionFields
            {
                TransactionDate = DateTime.Now,
                ComputerName= Environment.MachineName,
                UserTransaction = Environment.UserName
            };
        }
    }
}
