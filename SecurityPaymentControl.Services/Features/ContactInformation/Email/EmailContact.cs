using SecurityPaymentControl.Services.Features.Residents;
using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.ContactInformation.Email
{
    public class EmailContact : ControlTransactionFields
    {
        [Key]
        public string Email { get; set; }
        public string ResidentId { get; set; }

        public ResidentInformation ResidentInformation { get; set; }

    }
}