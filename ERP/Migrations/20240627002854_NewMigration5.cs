using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23e1e393-32c9-4105-9cea-83adf6961f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a400884f-ceb7-473e-a109-c64c1db24973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b812b218-250d-4cd8-97e8-35191f4cd1d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38432b18-f131-47ef-99c4-875dc9b93744", null, "zaposleni", "zaposleni" },
                    { "8d995c23-08fd-4ea3-bb9b-e1e9a161563a", null, "kupac", "kupac" },
                    { "d4854eb7-91af-45b8-aaf2-8b9b61d8be6b", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38432b18-f131-47ef-99c4-875dc9b93744");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d995c23-08fd-4ea3-bb9b-e1e9a161563a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4854eb7-91af-45b8-aaf2-8b9b61d8be6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23e1e393-32c9-4105-9cea-83adf6961f31", null, "kupac", "kupac" },
                    { "a400884f-ceb7-473e-a109-c64c1db24973", null, "zaposleni", "zaposleni" },
                    { "b812b218-250d-4cd8-97e8-35191f4cd1d8", null, "admin", "admin" }
                });
        }
    }
}
