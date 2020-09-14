using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityPaymentControl.Services.Migrations
{
    public partial class ChangeIntResidentValueToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResidentId",
                table: "PhoneContact",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ResidentId",
                table: "HouseInformation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ResidentId",
                table: "EmailContact",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "PhoneContact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "HouseInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "EmailContact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
