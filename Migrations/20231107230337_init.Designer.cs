﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using appapi.Data;

#nullable disable

namespace appapi.Migrations
{
    [DbContext(typeof(DbContextApi))]
    [Migration("20231107230337_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("appapi.Entity.AddressEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("city")
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("line_one")
                        .HasColumnType("TEXT");

                    b.Property<string>("line_second")
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("postcode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("appapi.Entity.UserEntity", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("first_name")
                        .HasColumnType("TEXT");

                    b.Property<int>("id_address")
                        .HasColumnType("INTEGER");

                    b.Property<string>("last_name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("appapi.Entity.AddressEntity", b =>
                {
                    b.HasOne("appapi.Entity.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("appapi.Entity.UserEntity", b =>
                {
                    b.HasOne("appapi.Entity.AddressEntity", "address")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");
                });
#pragma warning restore 612, 618
        }
    }
}
