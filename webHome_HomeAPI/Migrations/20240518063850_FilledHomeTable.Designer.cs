﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webHome_HomeAPI.Data;

#nullable disable

namespace webHome_HomeAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240518063850_FilledHomeTable")]
    partial class FilledHomeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webHome_HomeAPI.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Homes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 5, 18, 8, 38, 49, 703, DateTimeKind.Local).AddTicks(5275),
                            Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                            ImageUrl = "https://images.pexels.com/photos/106399/pexels-photo-106399.jpeg",
                            Name = "Home 1",
                            Occupancy = 5,
                            Rate = 200.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 5, 18, 8, 38, 49, 703, DateTimeKind.Local).AddTicks(5328),
                            Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                            ImageUrl = "https://images.pexels.com/photos/276724/pexels-photo-276724.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Home 2",
                            Occupancy = 3,
                            Rate = 240.0,
                            Sqft = 350,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 5, 18, 8, 38, 49, 703, DateTimeKind.Local).AddTicks(5331),
                            Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                            ImageUrl = "https://images.pexels.com/photos/259588/pexels-photo-259588.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Home 3",
                            Occupancy = 1,
                            Rate = 500.0,
                            Sqft = 120,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 5, 18, 8, 38, 49, 703, DateTimeKind.Local).AddTicks(5334),
                            Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                            ImageUrl = "https://images.pexels.com/photos/2102587/pexels-photo-2102587.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Home 4",
                            Occupancy = 10,
                            Rate = 50.0,
                            Sqft = 120,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 5, 18, 8, 38, 49, 703, DateTimeKind.Local).AddTicks(5337),
                            Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                            ImageUrl = "https://images.pexels.com/photos/323780/pexels-photo-323780.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Home 5",
                            Occupancy = 2,
                            Rate = 500.0,
                            Sqft = 240,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
