using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProudectImage",
                table: "Proudects");

            migrationBuilder.DropColumn(
                name: "ProudectLicence",
                table: "Proudects");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ads");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdImage",
                table: "Ads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProudectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Images_Proudects_ProudectId",
                        column: x => x.ProudectId,
                        principalTable: "Proudects",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdId",
                table: "Images",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AppUserID",
                table: "Images",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProudectId",
                table: "Images",
                column: "ProudectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Images_AdImage",
                table: "Ads",
                column: "AdImage",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImage",
                table: "AspNetUsers",
                column: "ProfileImage",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Images_AdImage",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Ads_AdImage",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdImage",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "ProudectImage",
                table: "Proudects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProudectLicence",
                table: "Proudects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
