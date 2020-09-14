using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SecurityPaymentControl.Services.DataContext;
using SecurityPaymentControl.Services.Features.ContactInformation.Email;
using SecurityPaymentControl.Services.Features.House;
using SecurityPaymentControl.Services.Features.Resident;
using SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone;
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

        public async Task<Response> GetResidents()
        {
            var getAllResidents = await _securityPaymentContext.ResidentInformation.ToListAsync();
          
            if (getAllResidents.Any())
            {
             
                return new Response { Data = getAllResidents };

            }
            return new Response { Message = "Residents table is empty!" };
        }

        public async Task<Response> SaveResident(ResidentRequest residentResquest)
        {
            var residentId = GetMaterializeResidentId(residentResquest.BlockNumber, residentResquest.HouseNumber);
            var getResidentDuplicated = _securityPaymentContext.ResidentInformation.ToList()
                .Find(x => x.ResidentInformationId == residentId);

            if (getResidentDuplicated == null)
            {
                ControlTransactionFields transactionInfo = TransactionInfo.GetTransactionInfo();

                IDbContextTransaction transaction = _securityPaymentContext.Database.BeginTransaction();
                ResidentInformation residentInformation = MaterializeGeneralResidentInformation(residentResquest, residentId, transactionInfo);
                PhoneContact phoneContact = MaterializeContactInformation(residentResquest, residentId, transactionInfo);
                EmailContact emailContact = MaterializeEmailContact(residentResquest, residentId, transactionInfo);
                HouseInformation houseInformation = MaterializeHouseInformation(residentResquest, residentId, transactionInfo);

                await _securityPaymentContext.AddAsync<ResidentInformation>(residentInformation);
                await _securityPaymentContext.AddAsync<PhoneContact>(phoneContact);
                await _securityPaymentContext.AddAsync<EmailContact>(emailContact);
                await _securityPaymentContext.AddAsync<HouseInformation>(houseInformation);

                await _securityPaymentContext.SaveChangesAsync();
                transaction.Commit();
                return new Response { Data = residentInformation };

            }
            return new Response { Message = "Failed, the resident already exist!" };
        }

        private HouseInformation MaterializeHouseInformation(ResidentRequest residentResquest, string residentId, ControlTransactionFields transactionInfo)
        {
            return new HouseInformation
            {
                HouseNumber= residentResquest.HouseNumber,
                BlockNumber= residentResquest.BlockNumber,
                ResidentId= residentId,
                TransactionDate = transactionInfo.TransactionDate,
                ComputerName = transactionInfo.ComputerName,
                UserTransaction = transactionInfo.UserTransaction
            };
        }

        private EmailContact MaterializeEmailContact(ResidentRequest residentResquest, string residentId, ControlTransactionFields transactionInfo)
        {
            return new EmailContact
            {
                Email= residentResquest.Email,
                ResidentId = residentId,
                TransactionDate = transactionInfo.TransactionDate,
                ComputerName = transactionInfo.ComputerName,
                UserTransaction = transactionInfo.UserTransaction
            };
        }

        private PhoneContact MaterializeContactInformation(ResidentRequest residentResquest, string residentId, ControlTransactionFields transactionInfo)
        {
            return new PhoneContact
            {
                PhoneNumber= residentResquest.PhoneNumber,
                CountryCode= residentResquest.CountryCode,
                ResidentId = residentId,
                TransactionDate = transactionInfo.TransactionDate,
                ComputerName = transactionInfo.ComputerName,
                UserTransaction = transactionInfo.UserTransaction
            };
        }

        private ResidentInformation MaterializeGeneralResidentInformation(ResidentRequest residentResquest, string residentId, ControlTransactionFields transactionInfo)
        {
            ResidentInformation residentInformation = new ResidentInformation.Builder(residentId, residentResquest.Name, residentResquest.LastName)
           .WithResidentInformationId(residentId)
           .WithName(residentResquest.Name)
           .WithLastName(residentResquest.LastName)
           .Build();

            residentInformation.TransactionDate = transactionInfo.TransactionDate;
            residentInformation.ComputerName = transactionInfo.ComputerName;
            residentInformation.UserTransaction = transactionInfo.UserTransaction;

            return residentInformation;
        }

        private string GetMaterializeResidentId(int blockNumber, int houseNumber)
        {
            var residentIdFormat = Strings.BlockLetter + blockNumber + Strings.HouseLetter + houseNumber;
            return residentIdFormat;
        }
    }
}
