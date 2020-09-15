﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityPaymentControl.Services.DataContext;

namespace SecurityPaymentControl.Services.Migrations
{
    [DbContext(typeof(SecurityPaymentContext))]
    partial class SecurityPaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Calendar.PaymentCalendar", b =>
                {
                    b.Property<int>("PaymentCalendarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComputerName");

                    b.Property<decimal>("PaymentCalendarAmmount");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("PaymentCalendarId");

                    b.ToTable("PaymentCalendar");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.ContactInformation.Email.EmailContact", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerName");

                    b.Property<string>("ResidentId");

                    b.Property<string>("ResidentInformationId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("Email");

                    b.HasIndex("ResidentInformationId");

                    b.ToTable("EmailContact");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.House.HouseInformation", b =>
                {
                    b.Property<int>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockNumber");

                    b.Property<string>("ComputerName");

                    b.Property<int>("HouseNumber");

                    b.Property<string>("ResidentId");

                    b.Property<string>("ResidentInformationId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("HouseId");

                    b.HasIndex("ResidentInformationId");

                    b.ToTable("HouseInformation");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone.PhoneContact", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerName");

                    b.Property<string>("CountryCode");

                    b.Property<string>("ResidentId");

                    b.Property<string>("ResidentInformationId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("PhoneNumber");

                    b.HasIndex("ResidentInformationId");

                    b.ToTable("PhoneContact");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", b =>
                {
                    b.Property<string>("ResidentInformationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerName");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("ResidentInformationId");

                    b.ToTable("ResidentInformation");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.VoucherResident.Voucher", b =>
                {
                    b.Property<int>("VoucherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComputerName");

                    b.Property<decimal>("PaymentAmmount");

                    b.Property<DateTime>("PaymentCalendarDate");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<decimal>("PendingAmmount");

                    b.Property<string>("ResidentId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("VoucherId");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.ContactInformation.Email.EmailContact", b =>
                {
                    b.HasOne("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", "ResidentInformation")
                        .WithMany("EmailContact")
                        .HasForeignKey("ResidentInformationId");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.House.HouseInformation", b =>
                {
                    b.HasOne("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", "ResidentInformation")
                        .WithMany("HouseInformation")
                        .HasForeignKey("ResidentInformationId");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone.PhoneContact", b =>
                {
                    b.HasOne("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", "ResidentInformation")
                        .WithMany("PhoneContact")
                        .HasForeignKey("ResidentInformationId");
                });
#pragma warning restore 612, 618
        }
    }
}
