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
    [Migration("20180303020252_fixed added ERA")]
    partial class fixedaddedERA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SalaryCapData.Models.HitterStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtBats");

                    b.Property<float>("Average");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Doubles");

                    b.Property<int>("ExtraBases");

                    b.Property<int>("GamesPlayed");

                    b.Property<int>("Hits");

                    b.Property<int>("HomeRuns");

                    b.Property<bool>("IsCumulative");

                    b.Property<int>("PlayerId");

                    b.Property<int>("RBI");

                    b.Property<int>("Runs");

                    b.Property<int>("Sacrifices");

                    b.Property<int>("StolenBases");

                    b.Property<int>("Strikeouts");

                    b.Property<int>("TotalBases");

                    b.Property<int>("Triples");

                    b.Property<int>("Walks");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("HitterStats");
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

            modelBuilder.Entity("SalaryCapData.Models.PitcherStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompleteGames");

                    b.Property<DateTime>("Date");

                    b.Property<float>("ERA");

                    b.Property<int>("EarnedRunsAllowed");

                    b.Property<int>("GamesFinished");

                    b.Property<int>("HitsAllowed");

                    b.Property<int>("Holds");

                    b.Property<float>("InningsPitched");

                    b.Property<bool>("IsCumulative");

                    b.Property<int>("Loses");

                    b.Property<int>("PickOffs");

                    b.Property<int>("PitcherWalks");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Saves");

                    b.Property<int>("Strikeouts");

                    b.Property<float>("WHIP");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("PitcherStats");
                });

            modelBuilder.Entity("SalaryCapData.Models.Player", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<decimal>("InitialValue");

                    b.Property<bool>("IsRookie");

                    b.Property<string>("LastName");

                    b.Property<string>("Position");

                    b.Property<int>("TeamId");

                    b.Property<int>("TotalPoints");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

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

            modelBuilder.Entity("SalaryCapData.Models.PlayerPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("PlayerPositions");
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerTransactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddedCount");

                    b.Property<int>("DroppedCount");

                    b.Property<int>("PlayerId");

                    b.Property<DateTime>("TradeDate");

                    b.HasKey("Id");

                    b.ToTable("PlayerTrades");
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Date");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.ToTable("PlayerValues");
                });

            modelBuilder.Entity("SalaryCapData.Models.Team", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Abbrev");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
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

            modelBuilder.Entity("SalaryCapData.Models.HitterStats", b =>
                {
                    b.HasOne("SalaryCapData.Models.Player", "Player")
                        .WithOne("HitterStats")
                        .HasForeignKey("SalaryCapData.Models.HitterStats", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.League", b =>
                {
                    b.HasOne("SalaryCapData.Models.Owner", "Commissioner")
                        .WithMany("Leagues")
                        .HasForeignKey("CommissionerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.PitcherStats", b =>
                {
                    b.HasOne("SalaryCapData.Models.Player", "Player")
                        .WithOne("PitcherStats")
                        .HasForeignKey("SalaryCapData.Models.PitcherStats", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.Player", b =>
                {
                    b.HasOne("SalaryCapData.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalaryCapData.Models.PlayerAssignment", b =>
                {
                    b.HasOne("SalaryCapData.Models.Franchise")
                        .WithMany("Players")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
