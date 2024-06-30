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
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetail_ShoppingCart_ShoppingCartShopping_Cart_ID",
                table: "CartDetail");

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

            migrationBuilder.DropColumn(
                name: "Is_deleted",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "ShoppingCart",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Shopping_Cart_ID",
                table: "ShoppingCart",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartShopping_Cart_ID",
                table: "CartDetail",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetail_ShoppingCartShopping_Cart_ID",
                table: "CartDetail",
                newName: "IX_CartDetail_ShoppingCartId");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23e1e393-32c9-4105-9cea-83adf6961f31", null, "kupac", "kupac" },
                    { "a400884f-ceb7-473e-a109-c64c1db24973", null, "zaposleni", "zaposleni" },
                    { "b812b218-250d-4cd8-97e8-35191f4cd1d8", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartId",
                table: "CartItem",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_ShoppingCart_ShoppingCartId",
                table: "CartDetail",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetail_ShoppingCart_ShoppingCartId",
                table: "CartDetail");

            migrationBuilder.DropTable(
                name: "CartItem");

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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCart",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingCart",
                newName: "Shopping_Cart_ID");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "CartDetail",
                newName: "ShoppingCartShopping_Cart_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetail_ShoppingCartId",
                table: "CartDetail",
                newName: "IX_CartDetail_ShoppingCartShopping_Cart_ID");

            migrationBuilder.AddColumn<bool>(
                name: "Is_deleted",
                table: "ShoppingCart",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3db8334b-4fae-4e60-90da-b9eb74005fcc", null, "zaposleni", "zaposleni" },
                    { "450b9211-20cb-460f-b0af-5498dc3423cb", null, "admin", "admin" },
                    { "c28dbd7c-904d-49df-a371-fc39f47b1111", null, "kupac", "kupac" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_ShoppingCart_ShoppingCartShopping_Cart_ID",
                table: "CartDetail",
                column: "ShoppingCartShopping_Cart_ID",
                principalTable: "ShoppingCart",
                principalColumn: "Shopping_Cart_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
