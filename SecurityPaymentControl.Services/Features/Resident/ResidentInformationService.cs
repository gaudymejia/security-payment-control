using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;
using SecurityPaymentControl.Services.DataContext;
using SecurityPaymentControl.Services.Features.Resident;
using SecurityPaymentControl.Services.Helpers;
using SecurityPaymentControl.Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Residents
{
    public class ResidentInformationService
    {
        private readonly SecurityPaymentContext _securityPaymentContext;
        public ResidentInformationService(SecurityPaymentContext securityPaymentContext)
        {
            _securityPaymentContext = securityPaymentContext;
        }

        public async Task<Response> SaveResident(ResidentRequest residentResquest)
        {
            var residentId = GetMaterializeResidentId(residentResquest.BlockNumber, residentResquest.HouseNumber);
            var getResidentDuplicated = _securityPaymentContext.ResidentInformation.ToList()
                .Find(x => x.ResidentInformationId == residentId);

            if (getResidentDuplicated == null)
            {
                IDbContextTransaction transaction = _securityPaymentContext.Database.BeginTransaction();
                ResidentInformation residentInformation = MaterializeGeneralResidentInformation(residentResquest, residentId);
                await _securityPaymentContext.AddAsync<ResidentInformation>(residentInformation);
                await _securityPaymentContext.SaveChangesAsync();
                transaction.Commit();
                return new Response { Data = residentInformation };

            }
            return new Response { Message = "Failed" };
        }

        private ResidentInformation MaterializeGeneralResidentInformation(ResidentRequest residentResquest, string residentId)
        {
            ControlTransactionFields transactionInfo = TransactionInfo.GetTransactionInfo();
            return new ResidentInformation
            {
                ResidentInformationId= residentId,
                Name= residentResquest.Name,
                LastName= residentResquest.LastName,
                TransactionDate= transactionInfo.TransactionDate,
                ComputerName= transactionInfo.ComputerName,
                UserTransaction= transactionInfo.UserTransaction             
            };

        }

        private string GetMaterializeResidentId(int blockNumber, int houseNumber)
        {
            var residentIdFormat = "B" + blockNumber + "C" + houseNumber;
            return residentIdFormat;
        }
    }
}
