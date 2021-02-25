﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWineCellar.DAL;

namespace MyWineCellar.DAL.Migrations
{
	[DbContext(typeof(MyWineCellarDbContext))]
    [Migration("20201109184155_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("MyWineCellar.DAL.Models.Wine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AcquisitionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AcquisitionMeans")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Appellation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Parcel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Vintage")
                        .HasColumnType("INTEGER")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("Appellation");

                    b.HasIndex("Country");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Parcel");

                    b.HasIndex("Producer");

                    b.HasIndex("Region");

                    b.ToTable("Wines");
                });
#pragma warning restore 612, 618
        }
    }
}
