using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPage.DAL.Migrations
{
    public partial class OrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItemShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartId",
                table: "ShopItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderId",
                table: "ShopItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_orderId",
                table: "ShopItems",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ShoppingCartId",
                table: "ShopItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_Orders_orderId",
                table: "ShopItems",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_ShoppingCarts_ShoppingCartId",
                table: "ShopItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_Orders_orderId",
                table: "ShopItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_ShoppingCarts_ShoppingCartId",
                table: "ShopItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ShopItems_orderId",
                table: "ShopItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopItems_ShoppingCartId",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "ShopItems");

            migrationBuilder.CreateTable(
                name: "ShopItemShoppingCart",
                columns: table => new
                {
                    CartsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemShoppingCart", x => new { x.CartsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ShopItemShoppingCart_ShopItems_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopItemShoppingCart_ShoppingCarts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemShoppingCart_ItemsId",
                table: "ShopItemShoppingCart",
                column: "ItemsId");
        }
    }
}
