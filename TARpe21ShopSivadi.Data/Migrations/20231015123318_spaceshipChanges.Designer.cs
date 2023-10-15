﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TARpe21ShopSivadi.Data;

#nullable disable

namespace TARpe21ShopSivadi.Data.Migrations
{
    [DbContext(typeof(TARpe21ShopSivadiContext))]
    [Migration("20231015123318_spaceshipChanges")]
    partial class spaceshipChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TARpe21ShopSivadi.Core.Domain.Spaceship.Dimension", b =>
                {
                    b.Property<int>("DimensionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DimensionID"), 1L, 1);

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<Guid?>("SpaceshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("DimensionID");

                    b.HasIndex("SpaceshipId");

                    b.ToTable("Dimension");
                });

            modelBuilder.Entity("TARpe21ShopSivadi.Core.Domain.Spaceship.Spaceship", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BuiltAtDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CargoWeight")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CrewCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.Property<int>("FuelConsumptionPerDay")
                        .HasColumnType("int");

                    b.Property<int>("FullTripsCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsSpaceshipPreviouslyOwned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastMaintenance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MaidenLaunch")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaintenanceCount")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSpeedInVaccuum")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("spaceships");
                });

            modelBuilder.Entity("TARpe21ShopSivadi.Core.Domain.Spaceship.Dimension", b =>
                {
                    b.HasOne("TARpe21ShopSivadi.Core.Domain.Spaceship.Spaceship", null)
                        .WithMany("Dimensions")
                        .HasForeignKey("SpaceshipId");
                });

            modelBuilder.Entity("TARpe21ShopSivadi.Core.Domain.Spaceship.Spaceship", b =>
                {
                    b.Navigation("Dimensions");
                });
#pragma warning restore 612, 618
        }
    }
}
