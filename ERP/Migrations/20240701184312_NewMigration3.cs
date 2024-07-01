using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10cde511-ade9-4a28-9592-95639d929bdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14102c8c-7584-4c77-b8b7-ed1bb802244f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d37c9d8d-73e8-4950-be86-4480f015f4b6");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Customer_LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Customer_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Customer_phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3baf727d-aae5-42a9-ac0e-ccf7e9b32662", null, "zaposleni", "ZAPOSLENI" },
                    { "83b2acc8-4511-4863-a8ca-bc543831fb8a", null, "kupac", "KUPAC" },
                    { "fdd114cb-d84f-4226-b6f2-ddc363ad1825", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3baf727d-aae5-42a9-ac0e-ccf7e9b32662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b2acc8-4511-4863-a8ca-bc543831fb8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdd114cb-d84f-4226-b6f2-ddc363ad1825");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10cde511-ade9-4a28-9592-95639d929bdb", null, "admin", "ADMIN" },
                    { "14102c8c-7584-4c77-b8b7-ed1bb802244f", null, "kupac", "KUPAC" },
                    { "d37c9d8d-73e8-4950-be86-4480f015f4b6", null, "zaposleni", "ZAPOSLENI" }
                });
        }
    }
}
