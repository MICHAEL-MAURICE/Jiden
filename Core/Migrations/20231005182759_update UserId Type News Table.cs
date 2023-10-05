using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updateUserIdTypeNewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_AppUserId1",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_AppUserId1",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "News",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_News_AppUserId",
                table: "News",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_AppUserId",
                table: "News",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_AppUserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_AppUserId",
                table: "News");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "News",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "News",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_AppUserId1",
                table: "News",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_AppUserId1",
                table: "News",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
