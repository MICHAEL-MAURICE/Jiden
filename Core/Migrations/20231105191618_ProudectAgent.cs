using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ProudectAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProudectAgentId",
                table: "GeographicalDistributionRanges",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProudectAgent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProudectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProudectAgent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProudectAgent_Proudects_ProudectId",
                        column: x => x.ProudectId,
                        principalTable: "Proudects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalDistributionRanges_ProudectAgentId",
                table: "GeographicalDistributionRanges",
                column: "ProudectAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProudectAgent_ProudectId",
                table: "ProudectAgent",
                column: "ProudectId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalDistributionRanges_ProudectAgent_ProudectAgentId",
                table: "GeographicalDistributionRanges",
                column: "ProudectAgentId",
                principalTable: "ProudectAgent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalDistributionRanges_ProudectAgent_ProudectAgentId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.DropTable(
                name: "ProudectAgent");

            migrationBuilder.DropIndex(
                name: "IX_GeographicalDistributionRanges_ProudectAgentId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.DropColumn(
                name: "ProudectAgentId",
                table: "GeographicalDistributionRanges");
        }
    }
}
