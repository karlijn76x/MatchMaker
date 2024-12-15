﻿// <auto-generated />
using System;
using MatchMaker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MatchMaker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241205091828_AddUserPreferenceWithKeys")]
    partial class AddUserPreferenceWithKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MatchMaker.Models.Entities.Champion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.Lane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lanes");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SummonerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.UserPreferences", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("LaneId")
                        .HasColumnType("int");

                    b.Property<int>("ChampionId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId", "LaneId", "ChampionId");

                    b.HasIndex("ChampionId");

                    b.HasIndex("LaneId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserPreferences");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.UserPreferences", b =>
                {
                    b.HasOne("MatchMaker.Models.Entities.Champion", "Champion")
                        .WithMany("UserPreferences")
                        .HasForeignKey("ChampionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatchMaker.Models.Entities.Lane", "Lane")
                        .WithMany("UserPreferences")
                        .HasForeignKey("LaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatchMaker.Models.Entities.Role", "Role")
                        .WithMany("UserPreferences")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatchMaker.Models.Entities.User", "User")
                        .WithMany("UserPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Champion");

                    b.Navigation("Lane");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.Champion", b =>
                {
                    b.Navigation("UserPreferences");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.Lane", b =>
                {
                    b.Navigation("UserPreferences");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.Role", b =>
                {
                    b.Navigation("UserPreferences");
                });

            modelBuilder.Entity("MatchMaker.Models.Entities.User", b =>
                {
                    b.Navigation("UserPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}