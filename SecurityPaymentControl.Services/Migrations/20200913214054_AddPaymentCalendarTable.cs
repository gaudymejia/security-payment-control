using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class AddPaymentCalendarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentCalendar",
                schema: "dbo",
                columns: table => new
                {
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    UserTransaction = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(nullable: true),
                    PaymentCalendarId = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentCalendarAmmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCalendar", x => x.PaymentCalendarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentCalendar",
                schema: "dbo");
        }
    }
}
