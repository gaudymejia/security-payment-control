using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext.Maps
{
    public class PhoneContactMap
    {
        public PhoneContactMap(EntityTypeBuilder<PhoneContact> builder)
        {
            builder.ToTable("PhoneContact", "dbo");
            builder.HasKey(c => c.PhoneNumber);
            builder.Property(c => c.PhoneNumber).HasMaxLength(200).IsRequired();
            builder.Property(c => c.CountryCode).HasMaxLength(200).IsRequired();
            builder.Property(c => c.ResidentId).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.ResidentInformation).WithMany(b => b.PhoneContact);
        }
    }
}
