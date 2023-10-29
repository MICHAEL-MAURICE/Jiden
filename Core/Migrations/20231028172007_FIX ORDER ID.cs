using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FIXORDERID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiptImage",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceiptImage",
                table: "Orders",
                column: "ReceiptImage",
                unique: true,
                filter: "[ReceiptImage] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_OrderId",
                table: "Images",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Orders_OrderId",
                table: "Images",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Images_ReceiptImage",
                table: "Orders",
                column: "ReceiptImage",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Orders_OrderId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Images_ReceiptImage",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReceiptImage",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Images_OrderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptImage",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
