using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingData.Migrations
{
    /// <inheritdoc />
    public partial class addCarMaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cars",
                newName: "Model");

            migrationBuilder.AddColumn<int>(
                name: "CarMakerId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarMakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarMakerId",
                table: "Cars",
                column: "CarMakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarMakers_CarMakerId",
                table: "Cars",
                column: "CarMakerId",
                principalTable: "CarMakers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarMakers_CarMakerId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarMakers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarMakerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarMakerId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Cars",
                newName: "Name");
        }
    }
}
