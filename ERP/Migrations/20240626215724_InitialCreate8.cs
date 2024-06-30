using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bb00ebf-916e-4f70-a169-936241b2b21b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7950f9a2-c7e6-45ae-a4e1-e73c10428c90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e4cbe46-d9d9-4fa3-a58b-f6a01a940677");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7fa8232c-230a-4864-b389-8eac0f596437", null, "zaposleni", "zaposleni" },
                    { "c07d9e20-4fe9-43d1-b0b8-ee0eb0cec3cb", null, "kupac", "kupac" },
                    { "efec2aff-049e-4054-85b2-f1dc64e2d82d", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa8232c-230a-4864-b389-8eac0f596437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c07d9e20-4fe9-43d1-b0b8-ee0eb0cec3cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efec2aff-049e-4054-85b2-f1dc64e2d82d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bb00ebf-916e-4f70-a169-936241b2b21b", null, "admin", "admin" },
                    { "7950f9a2-c7e6-45ae-a4e1-e73c10428c90", null, "kupac", "kupac" },
                    { "7e4cbe46-d9d9-4fa3-a58b-f6a01a940677", null, "zaposleni", "zaposleni" }
                });
        }
    }
}
