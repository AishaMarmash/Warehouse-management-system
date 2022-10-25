﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse_management_system.Data;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20221025173131_SupplierContainerRelationship")]
    partial class SupplierContainerRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContainerSupplier", b =>
                {
                    b.Property<int>("ContainersId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("ContainersId", "SuppliersId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("ContainerSupplier");
                });

            modelBuilder.Entity("NotePackage", b =>
                {
                    b.Property<int>("NotesId")
                        .HasColumnType("int");

                    b.Property<int>("PackagesId")
                        .HasColumnType("int");

                    b.HasKey("NotesId", "PackagesId");

                    b.HasIndex("PackagesId");

                    b.ToTable("NotePackage");
                });

            modelBuilder.Entity("Warehouse_management_system.Domain.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Warehouse_management_system.Domain.Models.SchedulingProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ActualIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedOut")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SchedulingProcesses");
                });

            modelBuilder.Entity("Warehouse_management_system.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("Warehouse_management_system.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContainerId")
                        .HasColumnType("int");

                    b.Property<string>("Dimintions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOut")
                        .HasColumnType("bit");

                    b.Property<int>("ScheduleProcessId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.HasIndex("ScheduleProcessId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Warehouse_management_system.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ContainerSupplier", b =>
                {
                    b.HasOne("Warehouse_management_system.Models.Container", null)
                        .WithMany()
                        .HasForeignKey("ContainersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_management_system.Models.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotePackage", b =>
                {
                    b.HasOne("Warehouse_management_system.Domain.Models.Note", null)
                        .WithMany()
                        .HasForeignKey("NotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_management_system.Models.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse_management_system.Models.Package", b =>
                {
                    b.HasOne("Warehouse_management_system.Models.Container", "Container")
                        .WithMany("Packages")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_management_system.Domain.Models.SchedulingProcess", "ScheduleProcess")
                        .WithMany("Packages")
                        .HasForeignKey("ScheduleProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");

                    b.Navigation("ScheduleProcess");
                });

            modelBuilder.Entity("Warehouse_management_system.Domain.Models.SchedulingProcess", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Warehouse_management_system.Models.Container", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
