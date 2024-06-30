using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63b8a6ce-13f5-4743-bb8a-adfec2a6e4a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "816441d6-e1c2-4cfa-899e-3820abc0d241");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3db4a62-d286-4fa2-ba72-0419b45b04ba");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "63b8a6ce-13f5-4743-bb8a-adfec2a6e4a5", null, "zaposleni", "zaposleni" },
                    { "816441d6-e1c2-4cfa-899e-3820abc0d241", null, "kupac", "kupac" },
                    { "c3db4a62-d286-4fa2-ba72-0419b45b04ba", null, "admin", "admin" }
                });
        }
    }
}
