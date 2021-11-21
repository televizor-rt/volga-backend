using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Televizor.VolgaIronHack.Entities.Migrations
{
    public partial class DeliveryRequestsRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParcelDeliveryStage");

            migrationBuilder.DropColumn(
                name: "AdditionalData",
                table: "TrainRouteStops");

            migrationBuilder.DropColumn(
                name: "StopTime",
                table: "TrainRouteStops");

            migrationBuilder.DropColumn(
                name: "AdditionalData",
                table: "TrainRoutes");

            migrationBuilder.DropColumn(
                name: "DeliveryDeadLine",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "DestinationStationExpressId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "SourceStationExpressId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "AcceptTime",
                table: "DeliveryRequests");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Parcels",
                newName: "TrainTripId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Parcels",
                newName: "RequestId1");

            migrationBuilder.RenameColumn(
                name: "InitiatorId",
                table: "Parcels",
                newName: "RequestId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StopTimeInMinutes",
                table: "TrainRouteStops",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KeeperId",
                table: "Parcels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Parcels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "DeliveryRequests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationStationId",
                table: "DeliveryRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InitiatorId",
                table: "DeliveryRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "DeliveryRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "DeliveryRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceStationId",
                table: "DeliveryRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "StatusChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    ActionCallerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusChanges_Parcels_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainTrips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChiefId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainRouteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainTrips_TrainRoutes_TrainRouteId",
                        column: x => x.TrainRouteId,
                        principalTable: "TrainRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_KeeperId",
                table: "Parcels",
                column: "KeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_RequestId1",
                table: "Parcels",
                column: "RequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_TrainTripId",
                table: "Parcels",
                column: "TrainTripId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRequests_DestinationStationId",
                table: "DeliveryRequests",
                column: "DestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRequests_SourceStationId",
                table: "DeliveryRequests",
                column: "SourceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusChanges_DeliveryId",
                table: "StatusChanges",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTrips_TrainRouteId",
                table: "TrainTrips",
                column: "TrainRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryRequests_Stations_DestinationStationId",
                table: "DeliveryRequests",
                column: "DestinationStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryRequests_Stations_SourceStationId",
                table: "DeliveryRequests",
                column: "SourceStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryRequests_Stations_DestinationStationId",
                table: "DeliveryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryRequests_Stations_SourceStationId",
                table: "DeliveryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_DeliveryRequests_RequestId1",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_TrainTrips_TrainTripId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Users_KeeperId",
                table: "Parcels");

            migrationBuilder.DropTable(
                name: "StatusChanges");

            migrationBuilder.DropTable(
                name: "TrainTrips");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_KeeperId",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_RequestId1",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_TrainTripId",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryRequests_DestinationStationId",
                table: "DeliveryRequests");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryRequests_SourceStationId",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StopTimeInMinutes",
                table: "TrainRouteStops");

            migrationBuilder.DropColumn(
                name: "KeeperId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "DestinationStationId",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "InitiatorId",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "SourceStationId",
                table: "DeliveryRequests");

            migrationBuilder.RenameColumn(
                name: "TrainTripId",
                table: "Parcels",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "RequestId1",
                table: "Parcels",
                newName: "ReceiverId");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Parcels",
                newName: "InitiatorId");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalData",
                table: "TrainRouteStops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StopTime",
                table: "TrainRouteStops",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalData",
                table: "TrainRoutes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDeadLine",
                table: "Parcels",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationStationExpressId",
                table: "Parcels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceStationExpressId",
                table: "Parcels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptTime",
                table: "DeliveryRequests",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParcelDeliveryStage",
                columns: table => new
                {
                    ParcelId = table.Column<Guid>(type: "uuid", nullable: false),
                    SerialId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    ParcelId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ParcelId2 = table.Column<Guid>(type: "uuid", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelDeliveryStage_Parcels_ParcelId2",
                        column: x => x.ParcelId2,
                        principalTable: "Parcels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParcelDeliveryStage_ParcelId1",
                table: "ParcelDeliveryStage",
                column: "ParcelId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelDeliveryStage_ParcelId2",
                table: "ParcelDeliveryStage",
                column: "ParcelId2");
        }
    }
}
