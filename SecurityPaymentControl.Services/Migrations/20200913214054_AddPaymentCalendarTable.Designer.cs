﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityPaymentControl.Services.DataContext;

namespace SecurityPaymentControl.Services.Migrations
{
    [DbContext(typeof(SecurityPaymentContext))]
    [Migration("20200913214054_AddPaymentCalendarTable")]
    partial class AddPaymentCalendarTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Calendar.PaymentCalendar", b =>
                {
                    b.Property<int>("PaymentCalendarId");

                    b.Property<string>("ComputerName");

                    b.Property<decimal>("PaymentCalendarAmmount");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("PaymentCalendarId");

                    b.ToTable("PaymentCalendar","dbo");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.ContactInformation.Email.EmailContact", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerName");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("Email");

                    b.HasIndex("ResidentId");

                    b.ToTable("EmailContact","dbo");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.House.HouseInformation", b =>
                {
                    b.Property<int>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockNumber");

                    b.Property<string>("ComputerName");

                    b.Property<int>("HouseNumber");

                    b.Property<int>("ResidentId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("HouseId");

                    b.HasIndex("ResidentId");

                    b.ToTable("HouseInformation");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone.PhoneContact", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerName");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("PhoneNumber");

                    b.HasIndex("ResidentId");

                    b.ToTable("PhoneContact","dbo");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", b =>
                {
                    b.Property<int>("ResidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComputerName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("ResidentId");

                    b.ToTable("ResidentInformation","dbo");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.ContactInformation.Email.EmailContact", b =>
                {
                    b.HasOne("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", "ResidentInformation")
                        .WithMany("EmailContact")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.House.HouseInformation", b =>
                {
                    b.HasOne("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", "ResidentInformation")
                        .WithMany("HouseInformation")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone.PhoneContact", b =>
                {
                    b.HasOne("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", "ResidentInformation")
                        .WithMany("PhoneContact")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
