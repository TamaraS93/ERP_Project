using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Again20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4697777-9885-4a0d-9c96-64eea2414579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5e1b99f-b627-4252-9fb5-9d4a2b9eeb99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7496da0-d135-4057-bdb9-ecb9ac256c5a");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Transaction_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Transaction_ID);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4697777-9885-4a0d-9c96-64eea2414579", null, "kupac", "kupac" },
                    { "c5e1b99f-b627-4252-9fb5-9d4a2b9eeb99", null, "zaposleni", "zaposleni" },
                    { "f7496da0-d135-4057-bdb9-ecb9ac256c5a", null, "admin", "admin" }
                });
        }
    }
}
