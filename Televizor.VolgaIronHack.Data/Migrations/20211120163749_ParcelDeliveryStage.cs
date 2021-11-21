using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Televizor.VolgaIronHack.Entities.Migrations
{
    public partial class ParcelDeliveryStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Parcels");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ParcelDeliveryStage",
                columns: table => new
                {
                    ParcelId = table.Column<Guid>(type: "uuid", nullable: false),
                    SerialId = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ParcelId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelDeliveryStage", x => new { x.ParcelId, x.SerialId });
                    table.ForeignKey(
                        name: "FK_ParcelDeliveryStage_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelDeliveryStage_Parcels_ParcelId1",
                        column: x => x.ParcelId1,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParcelDeliveryStage_ParcelId1",
                table: "ParcelDeliveryStage",
                column: "ParcelId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParcelDeliveryStage");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Parcels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
