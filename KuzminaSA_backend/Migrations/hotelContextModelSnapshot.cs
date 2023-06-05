﻿// <auto-generated />
using System;
using KuzminaSA_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KuzminaSA_backend.Migrations
{
    [DbContext(typeof(hotelContext))]
    partial class hotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("KuzminaSA_backend.Models.guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("happy_b")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("hotelid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("hotelid");

                    b.ToTable("guest");
                });

            modelBuilder.Entity("KuzminaSA_backend.Models.hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("hotel");
                });

            modelBuilder.Entity("KuzminaSA_backend.Models.room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("guest")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("room");
                });

            modelBuilder.Entity("KuzminaSA_backend.Models.user", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("hotelroom", b =>
                {
                    b.Property<int>("hotelid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("roomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("hotelid", "roomId");

                    b.HasIndex("roomId");

                    b.ToTable("hotelroom");
                });

            modelBuilder.Entity("KuzminaSA_backend.Models.guest", b =>
                {
                    b.HasOne("KuzminaSA_backend.Models.hotel", null)
                        .WithMany("guest")
                        .HasForeignKey("hotelid");
                });

            modelBuilder.Entity("hotelroom", b =>
                {
                    b.HasOne("KuzminaSA_backend.Models.hotel", null)
                        .WithMany()
                        .HasForeignKey("hotelid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuzminaSA_backend.Models.room", null)
                        .WithMany()
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KuzminaSA_backend.Models.hotel", b =>
                {
                    b.Navigation("guest");
                });
#pragma warning restore 612, 618
        }
    }
}
