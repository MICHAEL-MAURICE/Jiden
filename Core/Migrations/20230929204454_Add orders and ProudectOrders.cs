using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddordersandProudectOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentMethods_PaymentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectOrder_Order_OrderId",
                table: "ProudectOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectOrder_Proudects_ProudectId",
                table: "ProudectOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProudectOrder",
                table: "ProudectOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ProudectOrder",
                newName: "ProudectOrders");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_ProudectOrder_ProudectId",
                table: "ProudectOrders",
                newName: "IX_ProudectOrders_ProudectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProudectOrder_OrderId",
                table: "ProudectOrders",
                newName: "IX_ProudectOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PaymentId",
                table: "Orders",
                newName: "IX_Orders_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProudectOrders",
                table: "ProudectOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectOrders_Orders_OrderId",
                table: "ProudectOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectOrders_Proudects_ProudectId",
                table: "ProudectOrders",
                column: "ProudectId",
                principalTable: "Proudects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectOrders_Orders_OrderId",
                table: "ProudectOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectOrders_Proudects_ProudectId",
                table: "ProudectOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProudectOrders",
                table: "ProudectOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "ProudectOrders",
                newName: "ProudectOrder");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_ProudectOrders_ProudectId",
                table: "ProudectOrder",
                newName: "IX_ProudectOrder_ProudectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProudectOrders_OrderId",
                table: "ProudectOrder",
                newName: "IX_ProudectOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentId",
                table: "Order",
                newName: "IX_Order_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProudectOrder",
                table: "ProudectOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentMethods_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectOrder_Order_OrderId",
                table: "ProudectOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectOrder_Proudects_ProudectId",
                table: "ProudectOrder",
                column: "ProudectId",
                principalTable: "Proudects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
