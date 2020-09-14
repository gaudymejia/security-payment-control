using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class ChangeIdentityValueToManual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseInformation_ResidentInformation_ResidentId",
                table: "HouseInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_ResidentInformation_ResidentId",
                schema: "dbo",
                table: "EmailContact");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneContact_ResidentInformation_ResidentId",
                schema: "dbo",
                table: "PhoneContact");

            migrationBuilder.DropTable(
                name: "PaymentCalendar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Voucher",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_HouseInformation_ResidentId",
                table: "HouseInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentInformation",
                schema: "dbo",
                table: "ResidentInformation");

            migrationBuilder.DropIndex(
                name: "IX_PhoneContact_ResidentId",
                schema: "dbo",
                table: "PhoneContact");

            migrationBuilder.DropIndex(
                name: "IX_EmailContact_ResidentId",
                schema: "dbo",
                table: "EmailContact");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                schema: "dbo",
                table: "ResidentInformation");

            migrationBuilder.RenameTable(
                name: "ResidentInformation",
                schema: "dbo",
                newName: "ResidentInformation");

            migrationBuilder.RenameTable(
                name: "PhoneContact",
                schema: "dbo",
                newName: "PhoneContact");

            migrationBuilder.RenameTable(
                name: "EmailContact",
                schema: "dbo",
                newName: "EmailContact");

            migrationBuilder.AddColumn<string>(
                name: "ResidentInformationId",
                table: "HouseInformation",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResidentInformation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ResidentInformation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ResidentInformationId",
                table: "ResidentInformation",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "PhoneContact",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ResidentInformationId",
                table: "PhoneContact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentInformationId",
                table: "EmailContact",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentInformation",
                table: "ResidentInformation",
                column: "ResidentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseInformation_ResidentInformationId",
                table: "HouseInformation",
                column: "ResidentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneContact_ResidentInformationId",
                table: "PhoneContact",
                column: "ResidentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_ResidentInformationId",
                table: "EmailContact",
                column: "ResidentInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_ResidentInformation_ResidentInformationId",
                table: "EmailContact",
                column: "ResidentInformationId",
                principalTable: "ResidentInformation",
                principalColumn: "ResidentInformationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseInformation_ResidentInformation_ResidentInformationId",
                table: "HouseInformation",
                column: "ResidentInformationId",
                principalTable: "ResidentInformation",
                principalColumn: "ResidentInformationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneContact_ResidentInformation_ResidentInformationId",
                table: "PhoneContact",
                column: "ResidentInformationId",
                principalTable: "ResidentInformation",
                principalColumn: "ResidentInformationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_ResidentInformation_ResidentInformationId",
                table: "EmailContact");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseInformation_ResidentInformation_ResidentInformationId",
                table: "HouseInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneContact_ResidentInformation_ResidentInformationId",
                table: "PhoneContact");

            migrationBuilder.DropIndex(
                name: "IX_HouseInformation_ResidentInformationId",
                table: "HouseInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentInformation",
                table: "ResidentInformation");

            migrationBuilder.DropIndex(
                name: "IX_PhoneContact_ResidentInformationId",
                table: "PhoneContact");

            migrationBuilder.DropIndex(
                name: "IX_EmailContact_ResidentInformationId",
                table: "EmailContact");

            migrationBuilder.DropColumn(
                name: "ResidentInformationId",
                table: "HouseInformation");

            migrationBuilder.DropColumn(
                name: "ResidentInformationId",
                table: "ResidentInformation");

            migrationBuilder.DropColumn(
                name: "ResidentInformationId",
                table: "PhoneContact");

            migrationBuilder.DropColumn(
                name: "ResidentInformationId",
                table: "EmailContact");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "ResidentInformation",
                newName: "ResidentInformation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PhoneContact",
                newName: "PhoneContact",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmailContact",
                newName: "EmailContact",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "ResidentInformation",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "ResidentInformation",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                schema: "dbo",
                table: "ResidentInformation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "dbo",
                table: "PhoneContact",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentInformation",
                schema: "dbo",
                table: "ResidentInformation",
                column: "ResidentId");

            migrationBuilder.CreateTable(
                name: "PaymentCalendar",
                schema: "dbo",
                columns: table => new
                {
                    PaymentCalendarId = table.Column<int>(nullable: false),
                    ComputerName = table.Column<string>(nullable: true),
                    PaymentCalendarAmmount = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    UserTransaction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCalendar", x => x.PaymentCalendarId);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                schema: "dbo",
                columns: table => new
                {
                    VoucherId = table.Column<int>(nullable: false),
                    PaymentAmmount = table.Column<decimal>(nullable: false),
                    PaymentCalendarDate = table.Column<DateTime>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PendingAmmount = table.Column<decimal>(nullable: false),
                    ResidentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.VoucherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseInformation_ResidentId",
                table: "HouseInformation",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneContact_ResidentId",
                schema: "dbo",
                table: "PhoneContact",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_ResidentId",
                schema: "dbo",
                table: "EmailContact",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseInformation_ResidentInformation_ResidentId",
                table: "HouseInformation",
                column: "ResidentId",
                principalSchema: "dbo",
                principalTable: "ResidentInformation",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_ResidentInformation_ResidentId",
                schema: "dbo",
                table: "EmailContact",
                column: "ResidentId",
                principalSchema: "dbo",
                principalTable: "ResidentInformation",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneContact_ResidentInformation_ResidentId",
                schema: "dbo",
                table: "PhoneContact",
                column: "ResidentId",
                principalSchema: "dbo",
                principalTable: "ResidentInformation",
                principalColumn: "ResidentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
