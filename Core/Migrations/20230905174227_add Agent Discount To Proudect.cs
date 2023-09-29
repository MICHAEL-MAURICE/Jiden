using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addAgentDiscountToProudect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_ADID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AppUseriD",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Proudects_Proudectid",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AppUseriD",
                table: "Images");

            migrationBuilder.AddColumn<decimal>(
                name: "AgentDiscount",
                table: "Proudects",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUseriD",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ADID",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImage",
                table: "AspNetUsers",
                column: "ProfileImage",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_ADID",
                table: "Images",
                column: "ADID",
                principalTable: "Ads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Proudects_Proudectid",
                table: "Images",
                column: "Proudectid",
                principalTable: "Proudects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_ADID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Proudects_Proudectid",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AgentDiscount",
                table: "Proudects");

            migrationBuilder.AlterColumn<string>(
                name: "AppUseriD",
                table: "Images",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ADID",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AppUseriD",
                table: "Images",
                column: "AppUseriD");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImage",
                table: "AspNetUsers",
                column: "ProfileImage",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_ADID",
                table: "Images",
                column: "ADID",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AppUseriD",
                table: "Images",
                column: "AppUseriD",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Proudects_Proudectid",
                table: "Images",
                column: "Proudectid",
                principalTable: "Proudects",
                principalColumn: "Id");
        }
    }
}
