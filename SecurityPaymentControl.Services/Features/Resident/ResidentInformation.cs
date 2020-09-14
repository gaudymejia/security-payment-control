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
    public class ResidentInformation : ControlTransactionFields
    {
        [Key]
        public string ResidentInformationId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<PhoneContact> PhoneContact { get; set; }
        public List<EmailContact> EmailContact { get; set; }

        public List<HouseInformation> HouseInformation { get; set; }

        public void setResidentInformationId(string ResidentInformationId_Value)
        {
            ResidentInformationId = ResidentInformationId_Value;
        }
        public void setName(string Name_Value)
        {
            Name = Name_Value;
        }
        public void setLastName(string LastName_Value)
        {
            LastName = LastName_Value;
        }
        public sealed class Builder
        {
            private readonly ResidentInformation _residentInformation;
            public Builder(string residentInformation, string name, string lastName)
            {
                _residentInformation = new ResidentInformation
                {
                    ResidentInformationId = residentInformation,
                    Name = name,
                    LastName = lastName
                };
            }
            public Builder WithResidentInformationId(string ResidentInformationId_Value)
            {
                _residentInformation.ResidentInformationId = ResidentInformationId_Value;
                return this;
            }

            public Builder WithName(string Name_Value)
            {
                _residentInformation.Name = Name_Value;
                return this;
            }

            public Builder WithLastName(string LastName_Value)
            {
                _residentInformation.LastName = LastName_Value;
                return this;
            }
            public ResidentInformation Build()
            {
                return _residentInformation;
            }
        }
    }
}