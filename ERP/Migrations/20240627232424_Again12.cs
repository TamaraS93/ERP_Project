using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Again12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

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

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ShoppingCartId",
                table: "CartItems",
                newName: "IX_CartItems_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "CartItemId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4697777-9885-4a0d-9c96-64eea2414579", null, "kupac", "kupac" },
                    { "c5e1b99f-b627-4252-9fb5-9d4a2b9eeb99", null, "zaposleni", "zaposleni" },
                    { "f7496da0-d135-4057-bdb9-ecb9ac256c5a", null, "admin", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCart_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCart_ShoppingCartId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

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

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItem",
                newName: "IX_CartItem_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "CartItemId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29f1813f-37d3-4071-9f98-78eeba9500c1", null, "kupac", "kupac" },
                    { "af56eeaf-8625-4bfe-831a-126cd201712d", null, "admin", "admin" },
                    { "d088c555-92dd-451a-9f20-53ff0c9f4bdd", null, "zaposleni", "zaposleni" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                table: "CartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId");
        }
    }
}
