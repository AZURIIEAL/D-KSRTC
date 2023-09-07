using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_KSRTC.Migrations
{
    /// <inheritdoc />
    public partial class newtable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusRoute_Time_TimeId",
                table: "BusRoute");

            migrationBuilder.DropIndex(
                name: "IX_BusRoute_TimeId",
                table: "BusRoute");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "BusRoute");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "BusRoute",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "BusRoute");

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "BusRoute",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
