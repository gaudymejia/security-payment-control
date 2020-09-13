using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone
{
   
    public class PhoneContact : ControlTransactionFields
    {
        [Key]
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public int ResidentId { get; set; }

        public ResidentInformation ResidentInformation { get; set; }

    }
}
