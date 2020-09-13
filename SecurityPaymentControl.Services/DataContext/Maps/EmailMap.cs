using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityPaymentControl.Services.Features.ContactInformation.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext.Maps
{
    public class EmailMap
    {
        public EmailMap(EntityTypeBuilder<EmailContact> builder)
        {
            builder.ToTable("EmailContact", "dbo");
            builder.HasKey(c => c.Email);
            builder.Property(c => c.ResidentId).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.ResidentInformation).WithMany(b => b.EmailContact);
        }
    }
}
