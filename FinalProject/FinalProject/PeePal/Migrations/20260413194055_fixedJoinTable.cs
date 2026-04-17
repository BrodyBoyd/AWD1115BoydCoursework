using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeePal.Migrations
{
    /// <inheritdoc />
    public partial class fixedJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserBathroom");

            migrationBuilder.CreateTable(
                name: "UserFavoriteBathrooms",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BathroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteBathrooms", x => new { x.ApplicationUserId, x.BathroomId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteBathrooms_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFavoriteBathrooms_Bathrooms_BathroomId",
                        column: x => x.BathroomId,
                        principalTable: "Bathrooms",
                        principalColumn: "BathroomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteBathrooms_BathroomId",
                table: "UserFavoriteBathrooms",
                column: "BathroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoriteBathrooms");

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
    }
}
