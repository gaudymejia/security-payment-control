using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Resident
{
    public class ResidentRequest
    {
        public string ResidentInformationId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public int HouseNumber { get; set; }
        public int BlockNumber { get; set; }

    }
}
