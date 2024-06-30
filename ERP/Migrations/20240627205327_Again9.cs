using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Again9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29f1813f-37d3-4071-9f98-78eeba9500c1", null, "kupac", "kupac" },
                    { "af56eeaf-8625-4bfe-831a-126cd201712d", null, "admin", "admin" },
                    { "d088c555-92dd-451a-9f20-53ff0c9f4bdd", null, "zaposleni", "zaposleni" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f1813f-37d3-4071-9f98-78eeba9500c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af56eeaf-8625-4bfe-831a-126cd201712d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d088c555-92dd-451a-9f20-53ff0c9f4bdd");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
