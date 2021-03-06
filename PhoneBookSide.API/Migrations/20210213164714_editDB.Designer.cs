﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBookSide.API.Models.ORM.Context;

namespace PhoneBookSide.API.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    [Migration("20210213164714_editDB")]
    partial class editDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PhoneBookSide.API.Models.ORM.ConnectionInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("PersonID")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("context")
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("connectionInfos");
                });

            modelBuilder.Entity("PhoneBookSide.API.Models.ORM.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("people");
                });

            modelBuilder.Entity("PhoneBookSide.API.Models.ORM.ConnectionInfo", b =>
                {
                    b.HasOne("PhoneBookSide.API.Models.ORM.Person", "person")
                        .WithMany("Infos")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("PhoneBookSide.API.Models.ORM.Person", b =>
                {
                    b.Navigation("Infos");
                });
#pragma warning restore 612, 618
        }
    }
}
