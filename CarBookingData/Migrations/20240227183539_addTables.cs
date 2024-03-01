using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingData.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarColor_CarColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarColor",
                table: "CarColor");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "CarModels");

            migrationBuilder.RenameTable(
                name: "CarColor",
                newName: "CarColors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarColors",
                table: "CarColors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarColors_CarColorId",
                table: "Cars",
                column: "CarColorId",
                principalTable: "CarColors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarColors_CarColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarColors",
                table: "CarColors");

            migrationBuilder.RenameTable(
                name: "CarModels",
                newName: "CarModel");

            migrationBuilder.RenameTable(
                name: "CarColors",
                newName: "CarColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarColor",
                table: "CarColor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarColor_CarColorId",
                table: "Cars",
                column: "CarColorId",
                principalTable: "CarColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id");
        }
    }
}
