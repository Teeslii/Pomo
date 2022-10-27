﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.DBOperations;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(PomoDbContext))]
    [Migration("20221003193557_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Entities.MinuteSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MinuteSets");
                });

            modelBuilder.Entity("WebApi.Entities.Pomodoro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<int>("MinuteSetId")
                        .HasColumnType("int");

                    b.Property<bool>("PauseInMinutes")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MinuteSetId");

                    b.HasIndex("UserId");

                    b.ToTable("Pomodoros");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApi.Entities.Pomodoro", b =>
                {
                    b.HasOne("WebApi.Entities.MinuteSet", "MinuteSet")
                        .WithMany("Pomodoros")
                        .HasForeignKey("MinuteSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.User", "User")
                        .WithMany("Pomodoros")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MinuteSet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApi.Entities.MinuteSet", b =>
                {
                    b.Navigation("Pomodoros");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Navigation("Pomodoros");
                });
#pragma warning restore 612, 618
        }
    }
}
