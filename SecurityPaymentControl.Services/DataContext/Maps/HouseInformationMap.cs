using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecurityPaymentControl.Services.Features.House;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext.Maps
{
    public class HouseInformationMap
    {
        public HouseInformationMap(EntityTypeBuilder<HouseInformation> builder)
        {
            builder.ToTable("HouseInformation", "dbo");
            builder.Property(c => c.HouseId).ValueGeneratedNever();
            builder.Property(c => c.BlockNumber).HasColumnType("int").IsRequired();
            builder.Property(c => c.HouseNumber).HasColumnType("int").IsRequired();
            builder.Property(c => c.ResidentId).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.ResidentInformation).WithMany(b => b.HouseInformation);
        }
    }
}
