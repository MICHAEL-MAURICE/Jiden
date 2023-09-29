using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addImages3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_Adid",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Adid",
                table: "Images",
                newName: "AdiD"
               
                );

            migrationBuilder.RenameIndex(
                name: "IX_Images_Adid",
                table: "Images",
                newName: "IX_Images_AdiD"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdiD",
                table: "Images",
                column: "AdiD",
                principalTable: "Ads",
                principalColumn: "Id",
                
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdiD",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "AdiD",
                table: "Images",
                newName: "Adid");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AdiD",
                table: "Images",
                newName: "IX_Images_Adid");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_Adid",
                table: "Images",
                column: "Adid",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
