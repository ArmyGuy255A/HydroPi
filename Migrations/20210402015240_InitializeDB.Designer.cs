﻿// <auto-generated />
using System;
using HydroPi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HydroPi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210402015240_InitializeDB")]
    partial class InitializeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("HydroPi.Data.Models.Output", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Outputs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("abf475ba-42bd-4bdc-8717-99cb304c2f28"),
                            CreatedDate = new DateTime(2021, 4, 2, 1, 52, 40, 939, DateTimeKind.Utc).AddTicks(3507),
                            Name = "Output A"
                        },
                        new
                        {
                            Id = new Guid("51523f79-5af9-44b4-a584-db76a4b19ebf"),
                            CreatedDate = new DateTime(2021, 4, 2, 1, 52, 40, 939, DateTimeKind.Utc).AddTicks(3638),
                            Name = "Output B"
                        },
                        new
                        {
                            Id = new Guid("01615b17-5b76-4272-a23e-072297f42b39"),
                            CreatedDate = new DateTime(2021, 4, 2, 1, 52, 40, 939, DateTimeKind.Utc).AddTicks(3669),
                            Name = "Output C"
                        });
                });

            modelBuilder.Entity("HydroPi.Data.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sensors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd48a90a-b72b-4609-b422-7a633505ca3c"),
                            CreatedDate = new DateTime(2021, 4, 2, 1, 52, 40, 941, DateTimeKind.Utc).AddTicks(2827),
                            Name = "Sensor A"
                        },
                        new
                        {
                            Id = new Guid("44848670-502e-416c-822d-86d37f529401"),
                            CreatedDate = new DateTime(2021, 4, 2, 1, 52, 40, 941, DateTimeKind.Utc).AddTicks(2872),
                            Name = "Sensor B"
                        },
                        new
                        {
                            Id = new Guid("690a564d-77ee-45a6-bdab-3d91282c0cef"),
                            CreatedDate = new DateTime(2021, 4, 2, 1, 52, 40, 941, DateTimeKind.Utc).AddTicks(2899),
                            Name = "Sensor C"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}