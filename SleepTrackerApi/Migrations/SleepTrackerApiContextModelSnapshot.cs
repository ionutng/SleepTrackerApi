﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SleepTrackerApi.Data;

#nullable disable

namespace SleepTrackerApi.Migrations
{
    [DbContext(typeof(SleepTrackerApiContext))]
    partial class SleepTrackerApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SleepTrackerApi.Models.SleepRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("FallAsleepTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("WakeUpTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("SleepRecord");
                });
#pragma warning restore 612, 618
        }
    }
}