using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingData.Migrations
{
    /// <inheritdoc />
    public partial class addCarLicenseProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicensePlateNumber",
                table: "Cars",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlateNumber",
                table: "Cars");
        }
    }
}
