using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class AddPhoneContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneContact",
                columns: table => new
                {
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    UserTransaction = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    ResidentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneContact", x => x.PhoneNumber);
                    table.ForeignKey(
                        name: "FK_PhoneContact_ResidentInformation_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "ResidentInformation",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneContact_ResidentId",
                table: "PhoneContact",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneContact");
        }
    }
}
