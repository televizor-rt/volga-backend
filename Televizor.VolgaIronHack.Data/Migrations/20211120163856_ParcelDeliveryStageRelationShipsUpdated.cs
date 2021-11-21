using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Televizor.VolgaIronHack.Entities.Migrations
{
    public partial class ParcelDeliveryStageRelationShipsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParcelDeliveryStage_Parcels_ParcelId1",
                table: "ParcelDeliveryStage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParcelId1",
                table: "ParcelDeliveryStage",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ParcelId2",
                table: "ParcelDeliveryStage",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelDeliveryStage_ParcelId2",
                table: "ParcelDeliveryStage",
                column: "ParcelId2");

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelDeliveryStage_Parcels_ParcelId1",
                table: "ParcelDeliveryStage",
                column: "ParcelId1",
                principalTable: "Parcels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelDeliveryStage_Parcels_ParcelId2",
                table: "ParcelDeliveryStage",
                column: "ParcelId2",
                principalTable: "Parcels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParcelDeliveryStage_Parcels_ParcelId1",
                table: "ParcelDeliveryStage");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcelDeliveryStage_Parcels_ParcelId2",
                table: "ParcelDeliveryStage");

            migrationBuilder.DropIndex(
                name: "IX_ParcelDeliveryStage_ParcelId2",
                table: "ParcelDeliveryStage");

            migrationBuilder.DropColumn(
                name: "ParcelId2",
                table: "ParcelDeliveryStage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParcelId1",
                table: "ParcelDeliveryStage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelDeliveryStage_Parcels_ParcelId1",
                table: "ParcelDeliveryStage",
                column: "ParcelId1",
                principalTable: "Parcels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
