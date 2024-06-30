using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3bb00ebf-916e-4f70-a169-936241b2b21b", null, "admin", "admin" },
                    { "7950f9a2-c7e6-45ae-a4e1-e73c10428c90", null, "kupac", "kupac" },
                    { "7e4cbe46-d9d9-4fa3-a58b-f6a01a940677", null, "zaposleni", "zaposleni" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "4fcefcbb-6484-4622-8455-61ac265d3e63", null, "admin", "admin" },
                    { "6f88396c-3e3c-4121-b1d8-039de3ebbf2c", null, "zaposleni", "zaposleni" },
                    { "8cc18ca1-77c6-4046-af7a-4f7ffa8e31e2", null, "kupac", "kupac" }
                });
        }
    }
}
