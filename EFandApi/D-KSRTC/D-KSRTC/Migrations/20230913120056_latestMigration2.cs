using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_KSRTC.Migrations
{
    /// <inheritdoc />
    public partial class latestMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Passenger",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Passenger");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Booking",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
