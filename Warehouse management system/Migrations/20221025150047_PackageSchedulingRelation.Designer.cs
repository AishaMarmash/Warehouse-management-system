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
    [Migration("20221025150047_PackageSchedulingRelation")]
    partial class PackageSchedulingRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.ToTable("SchedulingProcess");
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
