using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Televizor.VolgaIronHack.Entities.Migrations
{
    public partial class DeliveryCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_DeliveryRequests_RequestId1",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_TrainTrips_TrainTripId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Users_KeeperId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusChanges_Parcels_DeliveryId",
                table: "StatusChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcels",
                table: "Parcels");

            migrationBuilder.RenameTable(
                name: "Parcels",
                newName: "Deliveries");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_TrainTripId",
                table: "Deliveries",
                newName: "IX_Deliveries_TrainTripId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_RequestId1",
                table: "Deliveries",
                newName: "IX_Deliveries_RequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_KeeperId",
                table: "Deliveries",
                newName: "IX_Deliveries_KeeperId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_DeliveryRequests_RequestId1",
                table: "Deliveries",
                column: "RequestId1",
                principalTable: "DeliveryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_TrainTrips_TrainTripId",
                table: "Deliveries",
                column: "TrainTripId",
                principalTable: "TrainTrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_KeeperId",
                table: "Deliveries",
                column: "KeeperId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusChanges_Deliveries_DeliveryId",
                table: "StatusChanges",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_DeliveryRequests_RequestId1",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_TrainTrips_TrainTripId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_KeeperId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusChanges_Deliveries_DeliveryId",
                table: "StatusChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries");

            migrationBuilder.RenameTable(
                name: "Deliveries",
                newName: "Parcels");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_TrainTripId",
                table: "Parcels",
                newName: "IX_Parcels_TrainTripId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_RequestId1",
                table: "Parcels",
                newName: "IX_Parcels_RequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_KeeperId",
                table: "Parcels",
                newName: "IX_Parcels_KeeperId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcels",
                table: "Parcels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_DeliveryRequests_RequestId1",
                table: "Parcels",
                column: "RequestId1",
                principalTable: "DeliveryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_TrainTrips_TrainTripId",
                table: "Parcels",
                column: "TrainTripId",
                principalTable: "TrainTrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Users_KeeperId",
                table: "Parcels",
                column: "KeeperId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusChanges_Parcels_DeliveryId",
                table: "StatusChanges",
                column: "DeliveryId",
                principalTable: "Parcels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
