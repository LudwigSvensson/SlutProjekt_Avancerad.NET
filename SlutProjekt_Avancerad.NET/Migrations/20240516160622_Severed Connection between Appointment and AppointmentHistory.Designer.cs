﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Avancerad.NET.Data;

#nullable disable

namespace SlutProjekt_Avancerad.NET.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240516160622_Severed Connection between Appointment and AppointmentHistory")]
    partial class SeveredConnectionbetweenAppointmentandAppointmentHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassModels.Appointment", b =>
                {
                    b.Property<int>("ApointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApointmentID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("int");

                    b.Property<int>("AppointmentType")
                        .HasColumnType("int");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.HasKey("ApointmentID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            ApointmentID = 1,
                            AppointmentDate = new DateTime(2024, 5, 16, 18, 6, 22, 245, DateTimeKind.Local).AddTicks(4424),
                            AppointmentStatus = 0,
                            AppointmentType = 0,
                            CompanyID = 2,
                            CustomerID = 1
                        },
                        new
                        {
                            ApointmentID = 2,
                            AppointmentDate = new DateTime(2024, 5, 16, 18, 6, 22, 245, DateTimeKind.Local).AddTicks(4459),
                            AppointmentStatus = 2,
                            AppointmentType = 2,
                            CompanyID = 3,
                            CustomerID = 2
                        },
                        new
                        {
                            ApointmentID = 3,
                            AppointmentDate = new DateTime(2024, 5, 16, 18, 6, 22, 245, DateTimeKind.Local).AddTicks(4469),
                            AppointmentStatus = 1,
                            AppointmentType = 1,
                            CompanyID = 1,
                            CustomerID = 3
                        });
                });

            modelBuilder.Entity("ClassModels.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyID"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyID = 1,
                            CompanyName = "Dagges tvätt"
                        },
                        new
                        {
                            CompanyID = 2,
                            CompanyName = "Mulles bilmeck"
                        },
                        new
                        {
                            CompanyID = 3,
                            CompanyName = "example ex"
                        });
                });

            modelBuilder.Entity("ClassModels.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            CustomerEmail = "ludwig@hotmail.com",
                            CustomerName = "Ludwig"
                        },
                        new
                        {
                            CustomerID = 2,
                            CustomerEmail = "robin@gmail.com",
                            CustomerName = "Robin"
                        },
                        new
                        {
                            CustomerID = 3,
                            CustomerEmail = "sara@yahoo.com",
                            CustomerName = "Sara"
                        });
                });

            modelBuilder.Entity("SlutProjekt_ClassLibrary.AppointmentHistory", b =>
                {
                    b.Property<int>("AppointmentHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentHistoryID"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActionTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("NewData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentHistoryID");

                    b.ToTable("AppointmentHistories");
                });

            modelBuilder.Entity("ClassModels.Appointment", b =>
                {
                    b.HasOne("ClassModels.Company", "Company")
                        .WithMany("Appointments")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassModels.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ClassModels.Company", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ClassModels.Customer", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
