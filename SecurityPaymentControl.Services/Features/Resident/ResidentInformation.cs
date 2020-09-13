using SecurityPaymentControl.Services.Features.ContactInformation.Email;
using SecurityPaymentControl.Services.Features.House;
using SecurityPaymentControl.Services.Features.Residents.ContactInformation;
using SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone;
using SecurityPaymentControl.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Residents
{
    public class ResidentInformation:ControlTransactionFields
    {
        [Key]
        public int ResidentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<PhoneContact> PhoneContact { get; set; }
        public List<EmailContact> EmailContact { get; set; }

        public List<HouseInformation> HouseInformation { get; set; }



    }
}
