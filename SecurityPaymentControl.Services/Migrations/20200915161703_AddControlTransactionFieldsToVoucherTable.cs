using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class AddControlTransactionFieldsToVoucherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResidentId",
                table: "Voucher",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ComputerName",
                table: "Voucher",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Voucher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserTransaction",
                table: "Voucher",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerName",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "UserTransaction",
                table: "Voucher");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Voucher",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
