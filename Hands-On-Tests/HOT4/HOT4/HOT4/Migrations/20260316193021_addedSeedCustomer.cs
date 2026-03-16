using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOT4.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "PhoneNumber", "Username" },
                values: new object[] { 1, "1234567890", "JohnDoe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);
        }
    }
}
