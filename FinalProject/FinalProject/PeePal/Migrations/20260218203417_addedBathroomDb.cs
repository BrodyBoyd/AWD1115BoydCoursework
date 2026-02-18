using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeePal.Migrations
{
    /// <inheritdoc />
    public partial class addedBathroomDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bathroom_AspNetUsers_ApplicationUserId",
                table: "Bathroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bathroom_BathroomId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bathroom",
                table: "Bathroom");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Bathroom",
                newName: "Bathrooms");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Bathrooms",
                newName: "Zip");

            migrationBuilder.RenameIndex(
                name: "IX_Bathroom_ApplicationUserId",
                table: "Bathrooms",
                newName: "IX_Bathrooms_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Bathrooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Bathrooms",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Bathrooms",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Bathrooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Bathrooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bathrooms",
                table: "Bathrooms",
                column: "BathroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bathrooms_AspNetUsers_ApplicationUserId",
                table: "Bathrooms",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bathrooms_BathroomId",
                table: "Reviews",
                column: "BathroomId",
                principalTable: "Bathrooms",
                principalColumn: "BathroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bathrooms_AspNetUsers_ApplicationUserId",
                table: "Bathrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bathrooms_BathroomId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bathrooms",
                table: "Bathrooms");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Bathrooms");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Bathrooms");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Bathrooms");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Bathrooms");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Bathrooms");

            migrationBuilder.RenameTable(
                name: "Bathrooms",
                newName: "Bathroom");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Bathroom",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Bathrooms_ApplicationUserId",
                table: "Bathroom",
                newName: "IX_Bathroom_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bathroom",
                table: "Bathroom",
                column: "BathroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bathroom_AspNetUsers_ApplicationUserId",
                table: "Bathroom",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bathroom_BathroomId",
                table: "Reviews",
                column: "BathroomId",
                principalTable: "Bathroom",
                principalColumn: "BathroomId");
        }
    }
}
