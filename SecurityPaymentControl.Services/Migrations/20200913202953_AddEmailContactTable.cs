using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class AddEmailContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockNumber",
                table: "ResidentInformation");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "ResidentInformation");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "ResidentInformation",
                newName: "ResidentInformation",
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

            migrationBuilder.CreateTable(
                name: "EmailContact",
                columns: table => new
                {
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    UserTransaction = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    ResidentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailContact", x => x.Email);
                    table.ForeignKey(
                        name: "FK_EmailContact_ResidentInformation_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "ResidentInformation",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_ResidentId",
                table: "EmailContact",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailContact");

            migrationBuilder.RenameTable(
                name: "ResidentInformation",
                schema: "dbo",
                newName: "ResidentInformation");

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

            migrationBuilder.AddColumn<int>(
                name: "BlockNumber",
                table: "ResidentInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "ResidentInformation",
                nullable: false,
                defaultValue: 0);
        }
    }
}
