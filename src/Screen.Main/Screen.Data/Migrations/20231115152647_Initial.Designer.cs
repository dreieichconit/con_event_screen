﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Screen.Data.Context;

#nullable disable

namespace Screen.Data.Migrations
{
    [DbContext(typeof(ScreenDbContext))]
    [Migration("20231115152647_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Screen.Data.Models.Configuration", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfigurationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("Screen.Data.Models.Marquee", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("ConfigurationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Show")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Marquees");
                });

            modelBuilder.Entity("Screen.Data.Models.Page", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("ConfigurationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DataFormat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemsPerPage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PageType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pagination")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SecondsVisible")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });
#pragma warning restore 612, 618
        }
    }
}