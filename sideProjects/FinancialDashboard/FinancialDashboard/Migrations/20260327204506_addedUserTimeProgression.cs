using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addedUserTimeProgression : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeProgressedInMonths",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeProgressedInMonths",
                table: "AspNetUsers");
        }
    }
}
