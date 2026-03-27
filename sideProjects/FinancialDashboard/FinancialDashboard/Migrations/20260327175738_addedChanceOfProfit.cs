using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addedChanceOfProfit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChanceOfProfit",
                table: "EarningMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 1,
                column: "ChanceOfProfit",
                value: 100);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 2,
                column: "ChanceOfProfit",
                value: 99);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 3,
                column: "ChanceOfProfit",
                value: 94);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 4,
                column: "ChanceOfProfit",
                value: 89);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 5,
                column: "ChanceOfProfit",
                value: 4);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 6,
                column: "ChanceOfProfit",
                value: 4);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 7,
                column: "ChanceOfProfit",
                value: 83);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 8,
                column: "ChanceOfProfit",
                value: 46);

            migrationBuilder.UpdateData(
                table: "EarningMethods",
                keyColumn: "EarningMethodId",
                keyValue: 9,
                column: "ChanceOfProfit",
                value: 94);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChanceOfProfit",
                table: "EarningMethods");
        }
    }
}
