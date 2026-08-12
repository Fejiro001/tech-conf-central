using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechConfCentral.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedConferenceEndDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conference",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: new DateOnly(2026, 11, 17));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conference",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: new DateOnly(2026, 11, 15));
        }
    }
}
