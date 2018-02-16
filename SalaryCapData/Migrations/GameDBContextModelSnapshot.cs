﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SalaryCapData;
using System;

namespace SalaryCapData.Migrations
{
    [DbContext(typeof(GameDBContext))]
    partial class GameDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalaryCapData.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("NumberOfTrades");

                    b.Property<int>("OwnerId");

                    b.Property<long>("Points");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Franchises");
                });

            modelBuilder.Entity("SalaryCapData.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommissionerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool>("IsPrivate");

                    b.Property<int>("MaxNumberFranchises");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Points");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CommissionerId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("SalaryCapData.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("SalaryCapData.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FranchiseId");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerAssignments");
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerAssignmentDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatePlayerDrafted");

                    b.Property<DateTime>("DatePlayerDropped");

                    b.HasKey("Id");

                    b.ToTable("PlayerAssignmentDates");
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerTrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Drafts");

                    b.Property<int>("Drops");

                    b.Property<int>("PlayerId");

                    b.Property<DateTime>("TradeDate");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerTrades");
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Date");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerValues");
                });

            modelBuilder.Entity("SalaryCapData.Models.Franchise", b =>
                {
                    b.HasOne("SalaryCapData.Models.League", "League")
                        .WithMany("Franchises")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SalaryCapData.Models.Owner", "Owner")
                        .WithMany("Franchises")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.League", b =>
                {
                    b.HasOne("SalaryCapData.Models.Owner", "Commissioner")
                        .WithMany("Leagues")
                        .HasForeignKey("CommissionerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerAssignment", b =>
                {
                    b.HasOne("SalaryCapData.Models.Franchise")
                        .WithMany("Players")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SalaryCapData.Models.Player")
                        .WithMany("Franchises")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerTrade", b =>
                {
                    b.HasOne("SalaryCapData.Models.Player")
                        .WithMany("PlayerTrades")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerValue", b =>
                {
                    b.HasOne("SalaryCapData.Models.Player")
                        .WithMany("PlayerValues")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
