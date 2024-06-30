using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_Category_ID1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Products_Category_ID1",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8edfe3b8-e4f2-419f-b3da-a02002e5b82e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc0e27f-6db8-4ec6-b2ff-e0c4e2f9967f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4699c01-fc20-421e-ae5f-1fc1fd8d6326");

            migrationBuilder.DropColumn(
                name: "Category_ID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Category_ID1",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Category_Select",
                table: "Products",
                newName: "Category");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3db8334b-4fae-4e60-90da-b9eb74005fcc", null, "zaposleni", "zaposleni" },
                    { "450b9211-20cb-460f-b0af-5498dc3423cb", null, "admin", "admin" },
                    { "c28dbd7c-904d-49df-a371-fc39f47b1111", null, "kupac", "kupac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3db8334b-4fae-4e60-90da-b9eb74005fcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "450b9211-20cb-460f-b0af-5498dc3423cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28dbd7c-904d-49df-a371-fc39f47b1111");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "Category_Select");

            migrationBuilder.AddColumn<int>(
                name: "Category_ID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category_ID1",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8edfe3b8-e4f2-419f-b3da-a02002e5b82e", null, "admin", "admin" },
                    { "9fc0e27f-6db8-4ec6-b2ff-e0c4e2f9967f", null, "kupac", "kupac" },
                    { "f4699c01-fc20-421e-ae5f-1fc1fd8d6326", null, "zaposleni", "zaposleni" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_ID1",
                table: "Products",
                column: "Category_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_Category_ID1",
                table: "Products",
                column: "Category_ID1",
                principalTable: "Category",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
