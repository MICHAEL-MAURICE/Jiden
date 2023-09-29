using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addPricingSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PricingSettingsId",
                table: "Proudects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Ads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Ads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PricingSettingsId",
                table: "Ads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Ads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PricingSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdPricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProudectPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proudects_PricingSettingsId",
                table: "Proudects",
                column: "PricingSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_PricingSettingsId",
                table: "Ads",
                column: "PricingSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_PricingSettings_PricingSettingsId",
                table: "Ads",
                column: "PricingSettingsId",
                principalTable: "PricingSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proudects_PricingSettings_PricingSettingsId",
                table: "Proudects",
                column: "PricingSettingsId",
                principalTable: "PricingSettings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_PricingSettings_PricingSettingsId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Proudects_PricingSettings_PricingSettingsId",
                table: "Proudects");

            migrationBuilder.DropTable(
                name: "PricingSettings");

            migrationBuilder.DropIndex(
                name: "IX_Proudects_PricingSettingsId",
                table: "Proudects");

            migrationBuilder.DropIndex(
                name: "IX_Ads_PricingSettingsId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "PricingSettingsId",
                table: "Proudects");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "PricingSettingsId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Ads");
        }
    }
}
