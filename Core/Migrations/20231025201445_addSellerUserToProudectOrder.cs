using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addSellerUserToProudectOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "JaidenMoney",
                table: "ProudectOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "sellerUser",
                table: "ProudectOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "FullJaidenMoney",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ProudectOrders_sellerUser",
                table: "ProudectOrders",
                column: "sellerUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectOrders_AspNetUsers_sellerUser",
                table: "ProudectOrders",
                column: "sellerUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProudectOrders_AspNetUsers_sellerUser",
                table: "ProudectOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProudectOrders_sellerUser",
                table: "ProudectOrders");

            migrationBuilder.DropColumn(
                name: "JaidenMoney",
                table: "ProudectOrders");

            migrationBuilder.DropColumn(
                name: "sellerUser",
                table: "ProudectOrders");

            migrationBuilder.DropColumn(
                name: "FullJaidenMoney",
                table: "Orders");
        }
    }
}
