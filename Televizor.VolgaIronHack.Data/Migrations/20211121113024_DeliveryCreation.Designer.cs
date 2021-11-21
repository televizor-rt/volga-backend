﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Televizor.VolgaIronHack.Entities;

#nullable disable

namespace Televizor.VolgaIronHack.Entities.Migrations
{
    [DbContext(typeof(VolgaIronHackDbContext))]
    [Migration("20211121113024_DeliveryCreation")]
    partial class DeliveryCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("KeeperId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequestId1")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("TrainTripId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("KeeperId");

                    b.HasIndex("RequestId1");

                    b.HasIndex("TrainTripId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.DeliveryRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeliveryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DestinationStationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("InitiatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<Guid>("SourceStationId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DestinationStationId");

                    b.HasIndex("SourceStationId");

                    b.ToTable("DeliveryRequests");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.DeliveryStatusChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ActionCallerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("StatusChanges");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExpressId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExpressName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.TrainRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ExpressId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TrainRoutes");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.TrainRouteStop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("MoscowArriveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("MoscowDepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("StopTimeInMinutes")
                        .HasColumnType("integer");

                    b.Property<Guid>("TrainRouteId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TrainRouteId1")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TrainRouteId");

                    b.HasIndex("TrainRouteId1");

                    b.ToTable("TrainRouteStops");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.TrainTrip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChiefId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TrainRouteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TrainRouteId");

                    b.ToTable("TrainTrips");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.Delivery", b =>
                {
                    b.HasOne("Televizor.VolgaIronHack.Entities.User", "Keeper")
                        .WithMany()
                        .HasForeignKey("KeeperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Televizor.VolgaIronHack.Entities.DeliveryRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Televizor.VolgaIronHack.Entities.TrainTrip", "Trip")
                        .WithMany()
                        .HasForeignKey("TrainTripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keeper");

                    b.Navigation("Request");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.DeliveryRequest", b =>
                {
                    b.HasOne("Televizor.VolgaIronHack.Entities.Station", "DestinationStation")
                        .WithMany()
                        .HasForeignKey("DestinationStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Televizor.VolgaIronHack.Entities.Station", "SourceStation")
                        .WithMany()
                        .HasForeignKey("SourceStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationStation");

                    b.Navigation("SourceStation");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.DeliveryStatusChange", b =>
                {
                    b.HasOne("Televizor.VolgaIronHack.Entities.Delivery", null)
                        .WithMany("StatusHistory")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.TrainRouteStop", b =>
                {
                    b.HasOne("Televizor.VolgaIronHack.Entities.TrainRoute", null)
                        .WithMany("Stops")
                        .HasForeignKey("TrainRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Televizor.VolgaIronHack.Entities.TrainRoute", null)
                        .WithMany()
                        .HasForeignKey("TrainRouteId1");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.TrainTrip", b =>
                {
                    b.HasOne("Televizor.VolgaIronHack.Entities.TrainRoute", "Route")
                        .WithMany()
                        .HasForeignKey("TrainRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.Delivery", b =>
                {
                    b.Navigation("StatusHistory");
                });

            modelBuilder.Entity("Televizor.VolgaIronHack.Entities.TrainRoute", b =>
                {
                    b.Navigation("Stops");
                });
#pragma warning restore 612, 618
        }
    }
}
