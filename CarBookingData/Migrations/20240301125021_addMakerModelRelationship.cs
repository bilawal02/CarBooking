using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingData.Migrations
{
    /// <inheritdoc />
    public partial class addMakerModelRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarMakerId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarMakerId",
                table: "CarModels",
                column: "CarMakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarMakers_CarMakerId",
                table: "CarModels",
                column: "CarMakerId",
                principalTable: "CarMakers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarMakers_CarMakerId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CarMakerId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CarMakerId",
                table: "CarModels");
        }
    }
}
