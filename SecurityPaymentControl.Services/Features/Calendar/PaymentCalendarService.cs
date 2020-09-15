using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SecurityPaymentControl.Services.DataContext;
using SecurityPaymentControl.Services.Helpers;
using SecurityPaymentControl.Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.Calendar
{
    public class PaymentCalendarService
    {

        private readonly SecurityPaymentContext _securityPaymentContext;
        public PaymentCalendarService(SecurityPaymentContext securityPaymentContext)
        {
            _securityPaymentContext = securityPaymentContext;
        }

        public async Task<Response> GetPaymentCallendarConfiguration()
        {
            var paymentCalendarConfiguration = await _securityPaymentContext.PaymentCalendar.ToListAsync();

            if (paymentCalendarConfiguration.Any())
            { 
                return new Response { Data = paymentCalendarConfiguration };

            }
            return new Response { Message = "Payment Calendar Configuration table is empty!" };
        }

        public async Task<Response> SavePaymentCalendarConfiguration(PaymentCalendarRequest paymentCalendarRequest)
        {
            var paymentConfigurationDuplicated = _securityPaymentContext.PaymentCalendar.ToList()
                .Find(x => x.PaymentDate == paymentCalendarRequest.PaymentDate);

            if (paymentConfigurationDuplicated == null)
            {
                ControlTransactionFields transactionInfo = TransactionInfo.GetTransactionInfo();

                IDbContextTransaction transaction = _securityPaymentContext.Database.BeginTransaction();
              
                PaymentCalendar paymentCalendarConfiguration = MaterializePaymentConfiguration(paymentCalendarRequest, transactionInfo);

                await _securityPaymentContext.AddAsync<PaymentCalendar>(paymentCalendarConfiguration);              
                await _securityPaymentContext.SaveChangesAsync();
                transaction.Commit();
                return new Response { Data = paymentCalendarConfiguration };

            }
            return new Response { Message = "Failed, the payment configuration already exist!" };
        }

        private PaymentCalendar MaterializePaymentConfiguration(PaymentCalendarRequest paymentCalendarRequest, ControlTransactionFields transactionInfo)
        {
            return new PaymentCalendar
            {
                PaymentDate = paymentCalendarRequest.PaymentDate,
                PaymentCalendarAmmount = paymentCalendarRequest.PaymentCalendarAmmount,
                TransactionDate = transactionInfo.TransactionDate,
                ComputerName = transactionInfo.ComputerName,
                UserTransaction = transactionInfo.UserTransaction
            };
        }
    }
}
