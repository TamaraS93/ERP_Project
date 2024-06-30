using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa8232c-230a-4864-b389-8eac0f596437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c07d9e20-4fe9-43d1-b0b8-ee0eb0cec3cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efec2aff-049e-4054-85b2-f1dc64e2d82d");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Employee_ID");

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

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Order_status_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Order_status_ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Shopping_Cart_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Shopping_Cart_ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_status_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrderStatusOrder_status_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusOrder_status_ID",
                        column: x => x.OrderStatusOrder_status_ID,
                        principalTable: "OrderStatus",
                        principalColumn: "Order_status_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    CartDetail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shopping_Cart_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Product_ID1 = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartShopping_Cart_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.CartDetail_ID);
                    table.ForeignKey(
                        name: "FK_CartDetail_Products_Product_ID1",
                        column: x => x.Product_ID1,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_ShoppingCart_ShoppingCartShopping_Cart_ID",
                        column: x => x.ShoppingCartShopping_Cart_ID,
                        principalTable: "ShoppingCart",
                        principalColumn: "Shopping_Cart_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Odred_Detail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_ID1 = table.Column<int>(type: "int", nullable: false),
                    Product_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Odred_Detail_ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_Order_ID1",
                        column: x => x.Order_ID1,
                        principalTable: "Order",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_Product_ID1",
                        column: x => x.Product_ID1,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_Product_ID1",
                table: "CartDetail",
                column: "Product_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ShoppingCartShopping_Cart_ID",
                table: "CartDetail",
                column: "ShoppingCartShopping_Cart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusOrder_status_ID",
                table: "Order",
                column: "OrderStatusOrder_status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_Order_ID1",
                table: "OrderDetail",
                column: "Order_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_Product_ID1",
                table: "OrderDetail",
                column: "Product_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_Category_ID1",
                table: "Products",
                column: "Category_ID1",
                principalTable: "Category",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_Category_ID1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_Products_Category_ID1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

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

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "Category_Select",
                table: "Products",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Employee_ID");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItem_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID1 = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItem_ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_Product_ID1",
                        column: x => x.Product_ID1,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7fa8232c-230a-4864-b389-8eac0f596437", null, "zaposleni", "zaposleni" },
                    { "c07d9e20-4fe9-43d1-b0b8-ee0eb0cec3cb", null, "kupac", "kupac" },
                    { "efec2aff-049e-4054-85b2-f1dc64e2d82d", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_Product_ID1",
                table: "CartItems",
                column: "Product_ID1");
        }
    }
}
