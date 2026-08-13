using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechConfCentral.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTalkDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2026, 11, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 16, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2026, 11, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 17, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2026, 11, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 18, 15, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2026, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2026, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2026, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 15, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
