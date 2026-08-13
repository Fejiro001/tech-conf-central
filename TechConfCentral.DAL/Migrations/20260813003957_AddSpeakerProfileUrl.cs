using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechConfCentral.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSpeakerProfileUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileImage",
                value: "https://api.dicebear.com/10.x/notionists/svg?seed=ElenaVasquez");

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfileImage",
                value: "https://api.dicebear.com/10.x/notionists/svg?seed=DineshChugtai");

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfileImage",
                value: "https://api.dicebear.com/10.x/notionists/svg?seed=JamesOkonkwo");

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsFeatured", "ProfileImage" },
                values: new object[] { true, "https://api.dicebear.com/10.x/notionists/svg?seed=Mei-LinZhang" });

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProfileImage",
                value: "https://api.dicebear.com/10.x/notionists/svg?seed=PriyaSharma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfileImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfileImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsFeatured", "ProfileImage" },
                values: new object[] { false, "" });

            migrationBuilder.UpdateData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProfileImage",
                value: "");
        }
    }
}
