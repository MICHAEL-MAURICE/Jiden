using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalDistributionRanges_Governorates_GovernorateId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.DropIndex(
                name: "IX_GeographicalDistributionRanges_GovernorateId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorateId",
                table: "GeographicalDistributionRanges",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalDistributionRanges_GovernorateId",
                table: "GeographicalDistributionRanges",
                column: "GovernorateId",
                unique: false,
                filter: "[GovernorateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalDistributionRanges_Governorates_GovernorateId",
                table: "GeographicalDistributionRanges",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalDistributionRanges_Governorates_GovernorateId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.DropIndex(
                name: "IX_GeographicalDistributionRanges_GovernorateId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorateId",
                table: "GeographicalDistributionRanges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalDistributionRanges_GovernorateId",
                table: "GeographicalDistributionRanges",
                column: "GovernorateId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalDistributionRanges_Governorates_GovernorateId",
                table: "GeographicalDistributionRanges",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
