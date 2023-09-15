﻿// <auto-generated />
using System;
using D_KSRTC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace D_KSRTC.Migrations
{
    [DbContext(typeof(DKSRTCContext))]
    partial class DKSRTCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("D_KSRTC.Models.Billing", b =>
                {
                    b.Property<int>("BillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingId"));

                    b.Property<DateTime>("BillingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BillingId");

                    b.HasIndex("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("Billing");
                });

            modelBuilder.Entity("D_KSRTC.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BusRouteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JourneyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("BusRouteId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("D_KSRTC.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<string>("BusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TCId")
                        .HasColumnType("int");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.HasIndex("TCId");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<float>("BaseFare")
                        .HasColumnType("real");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("BusCategory");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusRoute", b =>
                {
                    b.Property<int>("BusRouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusRouteId"));

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RouteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("BusRouteId");

                    b.HasIndex("BusId");

                    b.HasIndex("RouteId");

                    b.ToTable("BusRoute");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<float>("PDF")
                        .HasColumnType("real");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TypeId");

                    b.ToTable("BusType");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusTypeCategory", b =>
                {
                    b.Property<int>("TCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TCId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("TCId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeId");

                    b.ToTable("BusTypeCategory");
                });

            modelBuilder.Entity("D_KSRTC.Models.LocationDetails", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LocationId");

                    b.ToTable("LocationDetails");
                });

            modelBuilder.Entity("D_KSRTC.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FromLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ToLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.HasIndex("BookingId");

                    b.HasIndex("SeatId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("D_KSRTC.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("D_KSRTC.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<float>("Distance")
                        .HasColumnType("real");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ELId")
                        .HasColumnType("int");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SLId")
                        .HasColumnType("int");

                    b.HasKey("RouteId");

                    b.HasIndex("ELId");

                    b.HasIndex("SLId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("D_KSRTC.Models.RouteDetails", b =>
                {
                    b.Property<int>("RDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RDId"));

                    b.Property<float>("Distance")
                        .HasColumnType("real");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("StopId")
                        .HasColumnType("int");

                    b.HasKey("RDId");

                    b.HasIndex("RouteId");

                    b.HasIndex("StopId");

                    b.ToTable("RouteDetails");
                });

            modelBuilder.Entity("D_KSRTC.Models.Seat", b =>
                {
                    b.Property<int>("SeatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatID"));

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("BusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("SeatID");

                    b.HasIndex("BusID");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("D_KSRTC.Models.Time", b =>
                {
                    b.Property<int>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeId"));

                    b.Property<DateTime>("BusTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeId");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("D_KSRTC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("D_KSRTC.Models.Billing", b =>
                {
                    b.HasOne("D_KSRTC.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("D_KSRTC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("D_KSRTC.Models.Booking", b =>
                {
                    b.HasOne("D_KSRTC.Models.BusRoute", "BusRoute")
                        .WithMany()
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("D_KSRTC.Models.User", "userMapping")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BusRoute");

                    b.Navigation("userMapping");
                });

            modelBuilder.Entity("D_KSRTC.Models.Bus", b =>
                {
                    b.HasOne("D_KSRTC.Models.BusTypeCategory", "TCIdNavigation")
                        .WithMany()
                        .HasForeignKey("TCId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TCIdNavigation");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusRoute", b =>
                {
                    b.HasOne("D_KSRTC.Models.Bus", "BusIdNavigation")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("D_KSRTC.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BusIdNavigation");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusTypeCategory", b =>
                {
                    b.HasOne("D_KSRTC.Models.BusCategory", "CategoryIdNavigaton")
                        .WithMany("BusTypeCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("D_KSRTC.Models.BusType", "TypeIdNavigaton")
                        .WithMany("BusTypeCategories")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryIdNavigaton");

                    b.Navigation("TypeIdNavigaton");
                });

            modelBuilder.Entity("D_KSRTC.Models.Passenger", b =>
                {
                    b.HasOne("D_KSRTC.Models.Booking", "Booking")
                        .WithMany("PassengerNav")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("D_KSRTC.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("D_KSRTC.Models.Payment", b =>
                {
                    b.HasOne("D_KSRTC.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("D_KSRTC.Models.Route", b =>
                {
                    b.HasOne("D_KSRTC.Models.LocationDetails", "ELIdNavigation")
                        .WithMany()
                        .HasForeignKey("ELId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("D_KSRTC.Models.LocationDetails", "SLIdNavigation")
                        .WithMany()
                        .HasForeignKey("SLId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ELIdNavigation");

                    b.Navigation("SLIdNavigation");
                });

            modelBuilder.Entity("D_KSRTC.Models.RouteDetails", b =>
                {
                    b.HasOne("D_KSRTC.Models.Route", "RouteIdNavigation")
                        .WithMany("RouteDetails")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("D_KSRTC.Models.LocationDetails", "StopIdNavigation")
                        .WithMany()
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RouteIdNavigation");

                    b.Navigation("StopIdNavigation");
                });

            modelBuilder.Entity("D_KSRTC.Models.Seat", b =>
                {
                    b.HasOne("D_KSRTC.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("D_KSRTC.Models.Booking", b =>
                {
                    b.Navigation("PassengerNav");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusCategory", b =>
                {
                    b.Navigation("BusTypeCategories");
                });

            modelBuilder.Entity("D_KSRTC.Models.BusType", b =>
                {
                    b.Navigation("BusTypeCategories");
                });

            modelBuilder.Entity("D_KSRTC.Models.Route", b =>
                {
                    b.Navigation("RouteDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
