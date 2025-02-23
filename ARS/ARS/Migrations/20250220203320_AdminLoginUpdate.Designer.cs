﻿// <auto-generated />
using System;
using ARS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ARS.Migrations
{
    [DbContext(typeof(ContextCS))]
    [Migration("20250220203320_AdminLoginUpdate")]
    partial class AdminLoginUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ARS.Models.AdminPanel", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("AdminId");

                    b.ToTable("AdminLoginTable");
                });

            modelBuilder.Entity("ARS.Models.AeroPlaneInfo", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"));

                    b.Property<string>("APlaneName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("AeroPlaneInfo");
                });

            modelBuilder.Entity("ARS.Models.FlightBooking", b =>
                {
                    b.Property<int>("bid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bid"));

                    b.Property<string>("CusAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusCnic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CusSeat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaneInfoPlaneId")
                        .HasColumnType("int");

                    b.Property<int>("Planeid")
                        .HasColumnType("int");

                    b.Property<int>("ResId")
                        .HasColumnType("int");

                    b.Property<string>("SeatType")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("TicketReserve_tblsResId")
                        .HasColumnType("int");

                    b.Property<string>("bCusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bid");

                    b.HasIndex("PlaneInfoPlaneId");

                    b.HasIndex("TicketReserve_tblsResId");

                    b.ToTable("FlightBookTable");
                });

            modelBuilder.Entity("ARS.Models.TicketReserve_tbl", b =>
                {
                    b.Property<int>("ResId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResId"));

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaneId")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.Property<int>("PlaneSeat")
                        .HasColumnType("int");

                    b.Property<string>("ResDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResFtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResPlaneType")
                        .HasColumnType("int");

                    b.Property<float>("ResTicketPrice")
                        .HasColumnType("real");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("plane_tblsPlaneId")
                        .HasColumnType("int");

                    b.HasKey("ResId");

                    b.HasIndex("plane_tblsPlaneId");

                    b.ToTable("TicketReserve_tbl");
                });

            modelBuilder.Entity("ARS.Models.UserAccount", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CNo")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("CPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("UserID");

                    b.ToTable("UserLoginTable");
                });

            modelBuilder.Entity("ARS.Models.FlightBooking", b =>
                {
                    b.HasOne("ARS.Models.AeroPlaneInfo", "PlaneInfo")
                        .WithMany()
                        .HasForeignKey("PlaneInfoPlaneId");

                    b.HasOne("ARS.Models.TicketReserve_tbl", "TicketReserve_tbls")
                        .WithMany("FlightBookings")
                        .HasForeignKey("TicketReserve_tblsResId");

                    b.Navigation("PlaneInfo");

                    b.Navigation("TicketReserve_tbls");
                });

            modelBuilder.Entity("ARS.Models.TicketReserve_tbl", b =>
                {
                    b.HasOne("ARS.Models.AeroPlaneInfo", "plane_tbls")
                        .WithMany("TicketReserve_tbls")
                        .HasForeignKey("plane_tblsPlaneId");

                    b.Navigation("plane_tbls");
                });

            modelBuilder.Entity("ARS.Models.AeroPlaneInfo", b =>
                {
                    b.Navigation("TicketReserve_tbls");
                });

            modelBuilder.Entity("ARS.Models.TicketReserve_tbl", b =>
                {
                    b.Navigation("FlightBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
