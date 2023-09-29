using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addImages4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdiD",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "AdiD",
                table: "Images",
                newName: "ADID"
                
                );

            migrationBuilder.RenameIndex(
                name: "IX_Images_AdiD",
                table: "Images",
                newName: "IX_Images_ADID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_ADID",
                table: "Images",
                column: "ADID",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_ADID",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ADID",
                table: "Images",
                newName: "AdiD");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ADID",
                table: "Images",
                newName: "IX_Images_AdiD");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdiD",
                table: "Images",
                column: "AdiD",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
