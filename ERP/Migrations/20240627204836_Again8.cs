using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Again8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a2b83131-47ac-42cd-ad4f-1d019b0b9af0", null, "zaposleni", "zaposleni" },
                    { "d8cf816c-2b54-4f7e-b483-e3c85eb9ffd6", null, "kupac", "kupac" },
                    { "ebca72b6-7814-41f9-bb11-440ad253551d", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2b83131-47ac-42cd-ad4f-1d019b0b9af0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8cf816c-2b54-4f7e-b483-e3c85eb9ffd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebca72b6-7814-41f9-bb11-440ad253551d");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItem");

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
    }
}
