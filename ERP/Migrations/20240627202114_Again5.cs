using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Again5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0976be97-558b-4cca-8d60-979db5defb47", null, "zaposleni", "zaposleni" },
                    { "6e57d923-d893-4297-82fd-e5c9dddfba36", null, "kupac", "kupac" },
                    { "7ee90e37-31fe-40a7-bc98-b660379daabe", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0976be97-558b-4cca-8d60-979db5defb47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e57d923-d893-4297-82fd-e5c9dddfba36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ee90e37-31fe-40a7-bc98-b660379daabe");

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
    }
}
