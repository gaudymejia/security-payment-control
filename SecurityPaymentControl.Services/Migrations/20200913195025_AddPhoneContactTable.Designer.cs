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
    [Migration("20200913195025_AddPhoneContactTable")]
    partial class AddPhoneContactTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ContactInformation.Phone.PhoneContact", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerName");

                    b.Property<string>("CountryCode");

                    b.Property<int>("ResidentId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("PhoneNumber");

                    b.HasIndex("ResidentId");

                    b.ToTable("PhoneContact");
                });

            modelBuilder.Entity("SecurityPaymentControl.Services.Features.Residents.ResidentInformation", b =>
                {
                    b.Property<int>("ResidentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockNumber");

                    b.Property<string>("ComputerName");

                    b.Property<int>("HouseNumber");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("UserTransaction");

                    b.HasKey("ResidentId");

                    b.ToTable("ResidentInformation");
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
