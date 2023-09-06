using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_KSRTC.Migrations
{
    /// <inheritdoc />
    public partial class latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusRoute_Time_RouteId",
                table: "BusRoute");

            migrationBuilder.CreateIndex(
                name: "IX_BusRoute_TimeId",
                table: "BusRoute",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusRoute_Time_TimeId",
                table: "BusRoute",
                column: "TimeId",
                principalTable: "Time",
                principalColumn: "TimeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusRoute_Time_TimeId",
                table: "BusRoute");

            migrationBuilder.DropIndex(
                name: "IX_BusRoute_TimeId",
                table: "BusRoute");

            migrationBuilder.AddForeignKey(
                name: "FK_BusRoute_Time_RouteId",
                table: "BusRoute",
                column: "RouteId",
                principalTable: "Time",
                principalColumn: "TimeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
