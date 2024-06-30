using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7df3ac1f-14e3-4bbd-81e0-c48876bb202d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0e49fcb-bc6a-4a3f-a808-0c7e02e011c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5e20d8d-1994-40d2-a44a-2445c3983c08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6faaa406-0064-4339-84a0-855630148b6d", null, "zaposleni", "zaposleni" },
                    { "d3b38b24-9a1d-4fdf-9500-90ed2c562c2b", null, "kupac", "kupac" },
                    { "ee20f1e3-7ab0-47ae-9996-0a485eedc06e", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6faaa406-0064-4339-84a0-855630148b6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b38b24-9a1d-4fdf-9500-90ed2c562c2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee20f1e3-7ab0-47ae-9996-0a485eedc06e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7df3ac1f-14e3-4bbd-81e0-c48876bb202d", null, "zaposleni", "zaposleni" },
                    { "e0e49fcb-bc6a-4a3f-a808-0c7e02e011c8", null, "kupac", "kupac" },
                    { "e5e20d8d-1994-40d2-a44a-2445c3983c08", null, "admin", "admin" }
                });
        }
    }
}
