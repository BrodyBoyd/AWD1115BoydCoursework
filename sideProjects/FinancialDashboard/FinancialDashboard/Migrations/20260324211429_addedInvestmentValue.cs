using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addedInvestmentValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InvestmentValue",
                table: "Investments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestmentValue",
                table: "Investments");
        }
    }
}
