using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeePal.Migrations
{
    /// <inheritdoc />
    public partial class AddLatLngToReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Reviews",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Reviews",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Reviews");
        }
    }
}
