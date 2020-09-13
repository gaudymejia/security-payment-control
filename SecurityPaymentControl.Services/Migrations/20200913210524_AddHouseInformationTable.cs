using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class AddHouseInformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseInformation",
                columns: table => new
                {
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    UserTransaction = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockNumber = table.Column<int>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    ResidentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseInformation", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_HouseInformation_ResidentInformation_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "ResidentInformation",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseInformation_ResidentId",
                table: "HouseInformation",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseInformation");
        }
    }
}
