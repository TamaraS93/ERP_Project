using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Again22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aafa2031-6e9c-424f-a375-a9836ea065fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab2b017f-6f84-434e-9299-bacd48b1b0d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e85846b7-b430-474a-8626-9aa63b7461e7");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32371c79-1d7e-4761-811e-940e60a5d6ed", null, "admin", "admin" },
                    { "55f1c1da-702a-4b34-a350-eec9fa8b8640", null, "zaposleni", "zaposleni" },
                    { "932be064-92b2-4f9e-901d-ac8e4a06914f", null, "kupac", "kupac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32371c79-1d7e-4761-811e-940e60a5d6ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55f1c1da-702a-4b34-a350-eec9fa8b8640");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "932be064-92b2-4f9e-901d-ac8e4a06914f");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItems");

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aafa2031-6e9c-424f-a375-a9836ea065fe", null, "admin", "admin" },
                    { "ab2b017f-6f84-434e-9299-bacd48b1b0d6", null, "zaposleni", "zaposleni" },
                    { "e85846b7-b430-474a-8626-9aa63b7461e7", null, "kupac", "kupac" }
                });
        }
    }
}
