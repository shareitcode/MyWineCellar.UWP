﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWineCellar.DataAccessLayer;

namespace MyWineCellar.DataAccessLayer.Migrations
{
    [DbContext(typeof(MyWineCellarDbContext))]
    partial class MyWineCellarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("MyWineCellar.DataAccessLayer.Models.Wine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AcquisitionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AcquisitionMeans")
                        .HasColumnType("TEXT");

                    b.Property<string>("Appellation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Parcel")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Producer")
                        .HasColumnType("TEXT");

                    b.Property<short>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<short>("Vintage")
                        .HasColumnType("INTEGER");

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
