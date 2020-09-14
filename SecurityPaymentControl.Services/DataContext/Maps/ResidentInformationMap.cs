using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityPaymentControl.Services.Features.Residents;
using SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext.Maps
{
    public class ResidentInformationMap
    {
        public  ResidentInformationMap(EntityTypeBuilder<ResidentInformation> builder)
        {
            builder.ToTable("ResidentInformation", "dbo");
            builder.HasKey(c => c.ResidentInformationId);
            builder.Property(c => c.Name).HasMaxLength(200).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(200).IsRequired();
            builder.HasMany(p => p.PhoneContact).WithOne(b => b.ResidentInformation);
            builder.HasMany(p => p.EmailContact).WithOne(b => b.ResidentInformation);

        }
    }

}
