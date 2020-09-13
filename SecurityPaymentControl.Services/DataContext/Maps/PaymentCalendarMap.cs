using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityPaymentControl.Services.Features.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext.Maps
{
    public class PaymentCalendarMap
    {
        public PaymentCalendarMap(EntityTypeBuilder<PaymentCalendar> builder)
        {
            builder.ToTable("PaymentCalendar", "dbo");
            builder.Property(c => c.PaymentCalendarId).ValueGeneratedNever();
            builder.Property(c => c.PaymentDate).IsRequired();
            builder.Property(c => c.PaymentCalendarAmmount).IsRequired();
       }
    }
}
