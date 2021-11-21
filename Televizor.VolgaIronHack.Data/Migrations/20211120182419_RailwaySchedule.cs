using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Televizor.VolgaIronHack.Entities.Migrations
{
    public partial class RailwaySchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "DeliveryRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AcceptTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpressId = table.Column<string>(type: "text", nullable: false),
                    ExpressName = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    AdditionalData = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpressId = table.Column<string>(type: "text", nullable: false),
                    AdditionalData = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainRouteStops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainRouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    MoscowArriveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MoscowDepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StopTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    TrainRouteId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRouteStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainRouteStops_TrainRoutes_TrainRouteId",
                        column: x => x.TrainRouteId,
                        principalTable: "TrainRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainRouteStops_TrainRoutes_TrainRouteId1",
                        column: x => x.TrainRouteId1,
                        principalTable: "TrainRoutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainRouteStops_TrainRouteId",
                table: "TrainRouteStops",
                column: "TrainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRouteStops_TrainRouteId1",
                table: "TrainRouteStops",
                column: "TrainRouteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryRequests");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "TrainRouteStops");

            migrationBuilder.DropTable(
                name: "TrainRoutes");

            migrationBuilder.DropColumn(
                name: "DeliveryDeadLine",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "DestinationStationExpressId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "SourceStationExpressId",
                table: "Parcels");
        }
    }
}
