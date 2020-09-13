using SecurityPaymentControl.Services.Features.Residents;
using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.House
{
    public class HouseInformation: ControlTransactionFields
    {
        [Key]
        public int HouseId { get; set; }
        public int BlockNumber { get; set; }
        public int HouseNumber { get; set; }
        public int ResidentId { get; set; }
        public ResidentInformation ResidentInformation { get; set; }

    }
}
