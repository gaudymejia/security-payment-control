using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.House
{
    public class HouseInformation: ControlTransactionFields
    {
        public int BlockNumber { get; set; }
        public int HouseNumber { get; set; }
    }
}
