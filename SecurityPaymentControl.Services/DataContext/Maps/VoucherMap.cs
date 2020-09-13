using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityPaymentControl.Services.Features.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext.Maps
{
    public class VoucherMap
    {
        public VoucherMap(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Voucher", "dbo");
            builder.Property(c => c.VoucherId).ValueGeneratedNever();
            builder.Property(c => c.ResidentId).IsRequired();
            builder.Property(c => c.PaymentDate).IsRequired();
            builder.Property(c => c.PaymentCalendarDate).IsRequired();
            builder.Property(c => c.PaymentAmmount).IsRequired();
            builder.Property(c => c.PendingAmmount).IsRequired();

        }
    }
}
