using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37517885-5679-4cc6-b2a2-446d5f9ae437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3efef02f-7481-4789-b63c-c2e113749c6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9009022-f61f-45de-a798-28f40da73e34");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08287f9f-73e2-4f2b-b06c-de1fb54837e8", null, "zaposleni", "ZAPOSLENI" },
                    { "8c66bcba-450a-4739-b8ca-2996fa1c5ec0", null, "admin", "ADMIN" },
                    { "9374cb0e-9d86-41b9-a6fe-80dafc8ffafb", null, "kupac", "KUPAC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08287f9f-73e2-4f2b-b06c-de1fb54837e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c66bcba-450a-4739-b8ca-2996fa1c5ec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9374cb0e-9d86-41b9-a6fe-80dafc8ffafb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37517885-5679-4cc6-b2a2-446d5f9ae437", null, "zaposleni", "ZAPOSLENI" },
                    { "3efef02f-7481-4789-b63c-c2e113749c6f", null, "kupac", "KUPAC" },
                    { "b9009022-f61f-45de-a798-28f40da73e34", null, "admin", "ADMIN" }
                });
        }
    }
}
