using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeePal.Migrations
{
    /// <inheritdoc />
    public partial class AddedJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bathrooms_AspNetUsers_ApplicationUserId",
                table: "Bathrooms");

            migrationBuilder.DropIndex(
                name: "IX_Bathrooms_ApplicationUserId",
                table: "Bathrooms");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bathrooms");

            migrationBuilder.CreateTable(
                name: "ApplicationUserBathroom",
                columns: table => new
                {
                    FavoritedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavoritesBathroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserBathroom", x => new { x.FavoritedById, x.FavoritesBathroomId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserBathroom_AspNetUsers_FavoritedById",
                        column: x => x.FavoritedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserBathroom_Bathrooms_FavoritesBathroomId",
                        column: x => x.FavoritesBathroomId,
                        principalTable: "Bathrooms",
                        principalColumn: "BathroomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserBathroom_FavoritesBathroomId",
                table: "ApplicationUserBathroom",
                column: "FavoritesBathroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserBathroom");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bathrooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bathrooms_ApplicationUserId",
                table: "Bathrooms",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bathrooms_AspNetUsers_ApplicationUserId",
                table: "Bathrooms",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
