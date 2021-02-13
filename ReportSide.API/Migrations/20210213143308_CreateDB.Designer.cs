﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReportSide.API.Models.ORM.Context;

namespace ReportSide.API.Migrations
{
    [DbContext(typeof(ReportContext))]
    [Migration("20210213143308_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ReportSide.API.Models.ORM.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("personcount")
                        .HasColumnType("integer");

                    b.Property<int>("phonecount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("requesttime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.ToTable("reports");
                });
#pragma warning restore 612, 618
        }
    }
}
