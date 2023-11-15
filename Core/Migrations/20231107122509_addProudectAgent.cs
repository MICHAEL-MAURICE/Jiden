using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addProudectAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalDistributionRanges_ProudectAgent_ProudectAgentId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectAgent_Proudects_ProudectId",
                table: "ProudectAgent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProudectAgent",
                table: "ProudectAgent");

            migrationBuilder.RenameTable(
                name: "ProudectAgent",
                newName: "ProudectAgents");

            migrationBuilder.RenameIndex(
                name: "IX_ProudectAgent_ProudectId",
                table: "ProudectAgents",
                newName: "IX_ProudectAgents_ProudectId");

            migrationBuilder.AddColumn<decimal>(
                name: "JaidenMoney",
                table: "ProudectAgents",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "ProudectAgents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerUnit",
                table: "ProudectAgents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProudectNumber",
                table: "ProudectAgents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProudectAgents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sellerUser",
                table: "ProudectAgents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProudectAgents",
                table: "ProudectAgents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProudectAgents_OrderId",
                table: "ProudectAgents",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProudectAgents_sellerUser",
                table: "ProudectAgents",
                column: "sellerUser");

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalDistributionRanges_ProudectAgents_ProudectAgentId",
                table: "GeographicalDistributionRanges",
                column: "ProudectAgentId",
                principalTable: "ProudectAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectAgents_AspNetUsers_sellerUser",
                table: "ProudectAgents",
                column: "sellerUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectAgents_Orders_OrderId",
                table: "ProudectAgents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectAgents_Proudects_ProudectId",
                table: "ProudectAgents",
                column: "ProudectId",
                principalTable: "Proudects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalDistributionRanges_ProudectAgents_ProudectAgentId",
                table: "GeographicalDistributionRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectAgents_AspNetUsers_sellerUser",
                table: "ProudectAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectAgents_Orders_OrderId",
                table: "ProudectAgents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProudectAgents_Proudects_ProudectId",
                table: "ProudectAgents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProudectAgents",
                table: "ProudectAgents");

            migrationBuilder.DropIndex(
                name: "IX_ProudectAgents_OrderId",
                table: "ProudectAgents");

            migrationBuilder.DropIndex(
                name: "IX_ProudectAgents_sellerUser",
                table: "ProudectAgents");

            migrationBuilder.DropColumn(
                name: "JaidenMoney",
                table: "ProudectAgents");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProudectAgents");

            migrationBuilder.DropColumn(
                name: "PricePerUnit",
                table: "ProudectAgents");

            migrationBuilder.DropColumn(
                name: "ProudectNumber",
                table: "ProudectAgents");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProudectAgents");

            migrationBuilder.DropColumn(
                name: "sellerUser",
                table: "ProudectAgents");

            migrationBuilder.RenameTable(
                name: "ProudectAgents",
                newName: "ProudectAgent");

            migrationBuilder.RenameIndex(
                name: "IX_ProudectAgents_ProudectId",
                table: "ProudectAgent",
                newName: "IX_ProudectAgent_ProudectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProudectAgent",
                table: "ProudectAgent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalDistributionRanges_ProudectAgent_ProudectAgentId",
                table: "GeographicalDistributionRanges",
                column: "ProudectAgentId",
                principalTable: "ProudectAgent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProudectAgent_Proudects_ProudectId",
                table: "ProudectAgent",
                column: "ProudectId",
                principalTable: "Proudects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
