using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addImages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AppUserID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Proudects_ProudectId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ProudectId",
                table: "Images",
                newName: "Proudectid");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Images",
                newName: "AppUseriD");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Images",
                newName: "Adid");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProudectId",
                table: "Images",
                newName: "IX_Images_Proudectid");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AppUserID",
                table: "Images",
                newName: "IX_Images_AppUseriD");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AdId",
                table: "Images",
                newName: "IX_Images_Adid");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_Adid",
                table: "Images",
                column: "Adid",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AppUseriD",
                table: "Images",
                column: "AppUseriD",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Proudects_Proudectid",
                table: "Images",
                column: "Proudectid",
                principalTable: "Proudects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_Adid",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AppUseriD",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Proudects_Proudectid",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Proudectid",
                table: "Images",
                newName: "ProudectId");

            migrationBuilder.RenameColumn(
                name: "AppUseriD",
                table: "Images",
                newName: "AppUserID");

            migrationBuilder.RenameColumn(
                name: "Adid",
                table: "Images",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Proudectid",
                table: "Images",
                newName: "IX_Images_ProudectId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AppUseriD",
                table: "Images",
                newName: "IX_Images_AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Adid",
                table: "Images",
                newName: "IX_Images_AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdId",
                table: "Images",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AppUserID",
                table: "Images",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Proudects_ProudectId",
                table: "Images",
                column: "ProudectId",
                principalTable: "Proudects",
                principalColumn: "Id");
        }
    }
}
