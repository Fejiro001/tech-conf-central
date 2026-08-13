using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechConfCentral.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKeynoteIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Talk_ConferenceId",
                table: "Talk");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_ConferenceId",
                table: "Talk",
                column: "ConferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Talk_ConferenceId",
                table: "Talk");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_ConferenceId",
                table: "Talk",
                column: "ConferenceId",
                unique: true,
                filter: "[IsKeynote] = 1");
        }
    }
}
