using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4fcefcbb-6484-4622-8455-61ac265d3e63", null, "admin", "admin" },
                    { "6f88396c-3e3c-4121-b1d8-039de3ebbf2c", null, "zaposleni", "zaposleni" },
                    { "8cc18ca1-77c6-4046-af7a-4f7ffa8e31e2", null, "kupac", "kupac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fcefcbb-6484-4622-8455-61ac265d3e63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f88396c-3e3c-4121-b1d8-039de3ebbf2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc18ca1-77c6-4046-af7a-4f7ffa8e31e2");

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
    }
}
