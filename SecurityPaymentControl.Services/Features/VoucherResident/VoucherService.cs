using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SecurityPaymentControl.Services.DataContext;
using SecurityPaymentControl.Services.Helpers;
using SecurityPaymentControl.Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.VoucherResident
{
    public class VoucherService
    {
        private readonly SecurityPaymentContext _securityPaymentContext;
        public VoucherService(SecurityPaymentContext securityPaymentContext)
        {
            _securityPaymentContext = securityPaymentContext;
        }

        public async Task<Response> GetVouchersByResidentId(string residentId)
        {
            var vouchers = await _securityPaymentContext.Voucher.ToListAsync();
            var vouchersByResident = vouchers.Where(m => m.ResidentId == residentId).ToList();
            if (vouchersByResident.Any())
            {
                return new Response { Data = vouchersByResident };

            }
            return new Response { Message = "Resident doesn't exist!" };
        }

        public async Task<Response> SaveVoucher(VoucherRequest voucherRequest)
        {
            var existResident = _securityPaymentContext.ResidentInformation.ToList().FirstOrDefault(c => c.ResidentInformationId == voucherRequest.ResidentId);

            var paymentCalendarConfigurationExist = _securityPaymentContext.PaymentCalendar.ToList()
                .Where(x=> x.PaymentDate.Year==voucherRequest.PaymentCalendarDate.Year &&
                x.PaymentDate.Month == voucherRequest.PaymentCalendarDate.Month &&
                x.PaymentDate.Day == voucherRequest.PaymentCalendarDate.Day).ToList();

            if (paymentCalendarConfigurationExist != null && existResident.ResidentInformationId==voucherRequest.ResidentId)
            {
                ControlTransactionFields transactionInfo = TransactionInfo.GetTransactionInfo();

                IDbContextTransaction transaction = _securityPaymentContext.Database.BeginTransaction();

                Voucher paymentCalendarConfiguration = MaterializeVoucherByResident(voucherRequest, transactionInfo);

                await _securityPaymentContext.AddAsync<Voucher>(paymentCalendarConfiguration);
                await _securityPaymentContext.SaveChangesAsync();
                transaction.Commit();
                return new Response { Data = paymentCalendarConfiguration };

            }
            return new Response { Message = "Failed, the payment configuration already exist!" };
        }

        private Voucher MaterializeVoucherByResident(VoucherRequest voucherRequest, ControlTransactionFields transactionInfo)
        {
            return new Voucher
            {
                ResidentId= voucherRequest.ResidentId,
                PaymentCalendarDate = voucherRequest.PaymentCalendarDate,
                PaymentDate= voucherRequest.PaymentDate,
                PaymentAmmount = voucherRequest.PaymentAmmount,
                PendingAmmount = voucherRequest.PendingAmmount,
                TransactionDate = transactionInfo.TransactionDate,
                ComputerName = transactionInfo.ComputerName,
                UserTransaction = transactionInfo.UserTransaction
            };
        }



    }
}
