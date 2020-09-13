using Microsoft.EntityFrameworkCore;
using SecurityPaymentControl.Services.Features.Residents;
using SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.DataContext
{
    public class SecurityPaymentContext : DbContext
    {
        public SecurityPaymentContext(DbContextOptions<SecurityPaymentContext> options) : base(options) { }

        public DbSet<ResidentInformation> ResidentInformation { get; set; }
        public DbSet<PhoneContact> PhoneContact { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResidentInformation>().ToTable("ResidentInformation");
            modelBuilder.Entity<PhoneContact>().ToTable("PhoneContact");

            modelBuilder.Entity<PhoneContact>().HasOne(p => p.ResidentInformation).WithMany(b => b.PhoneContact);
        }


    }
}
