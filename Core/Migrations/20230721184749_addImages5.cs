using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addImages5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Images_ADID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AppUseriD",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Ads_AdImage",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ADID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AppUseriD",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Proudectid",
                table: "Images",
                newName: "ProudectId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Proudectid",
                table: "Images",
                newName: "IX_Images_ProudectId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileImage",
                table: "AspNetUsers",
                column: "ProfileImage");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AdImage",
                table: "Ads",
                column: "AdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Proudects_ProudectId",
                table: "Images",
                column: "ProudectId",
                principalTable: "Proudects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Proudects_ProudectId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Ads_AdImage",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "ProudectId",
                table: "Images",
                newName: "Proudectid");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProudectId",
                table: "Images",
                newName: "IX_Images_Proudectid");

            migrationBuilder.AddColumn<Guid>(
                name: "ADID",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AppUseriD",
                table: "Images",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ADID",
                table: "Images",
                column: "ADID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AppUseriD",
                table: "Images",
                column: "AppUseriD");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileImage",
                table: "AspNetUsers",
                column: "ProfileImage",
                unique: true,
                filter: "[ProfileImage] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AdImage",
                table: "Ads",
                column: "AdImage",
                unique: true,
                filter: "[AdImage] IS NOT NULL");

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
