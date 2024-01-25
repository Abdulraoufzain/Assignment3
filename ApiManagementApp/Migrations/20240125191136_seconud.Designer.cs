﻿// <auto-generated />
using System;
using ApiManagementApp.MDmContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiManagementApp.Migrations
{
    [DbContext(typeof(ManagmentDbContexts))]
    [Migration("20240125191136_seconud")]
    partial class seconud
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Management.Car", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Gear")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("KM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KmKm")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("KM\r\nKM")
                        .IsFixedLength();

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Management.CarsPart", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasIndex("CarId");

                    b.HasIndex("PartId");

                    b.ToTable("CarsParts");
                });

            modelBuilder.Entity("Management.Customer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Management.Part", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Qunantity")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<int>("SupliersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupliersId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Management.Sale", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CoustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CoustomerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Management.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Management.CarsPart", b =>
                {
                    b.HasOne("Management.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK_CarsParts_Cars");

                    b.HasOne("Management.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .IsRequired()
                        .HasConstraintName("FK_CarsParts_Parts");

                    b.Navigation("Car");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Management.Part", b =>
                {
                    b.HasOne("Management.Supplier", "Supliers")
                        .WithMany("Parts")
                        .HasForeignKey("SupliersId")
                        .IsRequired()
                        .HasConstraintName("FK_Parts_Suppliers");

                    b.Navigation("Supliers");
                });

            modelBuilder.Entity("Management.Sale", b =>
                {
                    b.HasOne("Management.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK_Sales_Cars");

                    b.HasOne("Management.Customer", "Coustomer")
                        .WithMany("Sales")
                        .HasForeignKey("CoustomerId")
                        .IsRequired()
                        .HasConstraintName("rela");

                    b.Navigation("Car");

                    b.Navigation("Coustomer");
                });

            modelBuilder.Entity("Management.Car", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Management.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Management.Supplier", b =>
                {
                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
