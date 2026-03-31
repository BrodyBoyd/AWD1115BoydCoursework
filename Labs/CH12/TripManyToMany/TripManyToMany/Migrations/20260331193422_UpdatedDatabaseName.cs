using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTrip_Activitys_ActivitiesActivityId",
                table: "ActivityTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys");

            migrationBuilder.RenameTable(
                name: "Activitys",
                newName: "Activities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTrip_Activities_ActivitiesActivityId",
                table: "ActivityTrip",
                column: "ActivitiesActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTrip_Activities_ActivitiesActivityId",
                table: "ActivityTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTrip_Activitys_ActivitiesActivityId",
                table: "ActivityTrip",
                column: "ActivitiesActivityId",
                principalTable: "Activitys",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
