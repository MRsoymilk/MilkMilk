﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilkMilk.Data;

namespace MilkMilk.Migrations
{
    [DbContext(typeof(MilkMilkContext))]
    partial class MilkMilkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MilkMilk.Models.Blog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("release_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Blog");
                });
#pragma warning restore 612, 618
        }
    }
}
