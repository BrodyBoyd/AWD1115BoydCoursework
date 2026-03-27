using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addedYearlyIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "YearlyIncome",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearlyIncome",
                table: "AspNetUsers");
        }
    }
}
