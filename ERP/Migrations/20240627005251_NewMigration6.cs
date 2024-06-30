using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0fa02dbc-44dd-4b6a-a5ef-ccfba91413e9", null, "admin", "admin" },
                    { "e3a2419a-10d9-43a3-a873-d7038cd2637d", null, "zaposleni", "zaposleni" },
                    { "e7bcb0b1-c094-4dec-a8e5-126bdd709140", null, "kupac", "kupac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fa02dbc-44dd-4b6a-a5ef-ccfba91413e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3a2419a-10d9-43a3-a873-d7038cd2637d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7bcb0b1-c094-4dec-a8e5-126bdd709140");

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
    }
}
