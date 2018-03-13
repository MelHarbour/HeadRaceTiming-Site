﻿// <auto-generated />
using HeadRaceTimingSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HeadRaceTimingSite.Migrations
{
    [DbContext(typeof(TimingSiteContext))]
    [Migration("20180313103252_Penalties")]
    partial class Penalties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeadRaceTimingSite.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Athlete", b =>
                {
                    b.Property<int>("AthleteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MembershipNumber");

                    b.HasKey("AthleteId");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Award", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompetitionId");

                    b.Property<bool>("IsMasters");

                    b.Property<string>("Title");

                    b.HasKey("AwardId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BackgroundArgb");

                    b.Property<string>("FriendlyName");

                    b.Property<string>("ImageUriText");

                    b.Property<bool>("IsVisible");

                    b.Property<string>("Name");

                    b.Property<bool>("ShowFirstIntermediate");

                    b.Property<bool>("ShowSecondIntermediate");

                    b.Property<int>("TextArgb");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Crew", b =>
                {
                    b.Property<int>("CrewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BroeCrewId");

                    b.Property<string>("ClubCode");

                    b.Property<int>("CompetitionId");

                    b.Property<bool>("IsTimeOnly");

                    b.Property<string>("Name");

                    b.Property<int>("StartNumber");

                    b.Property<int>("Status");

                    b.HasKey("CrewId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.CrewAthlete", b =>
                {
                    b.Property<int>("CrewAthleteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AthleteId");

                    b.Property<int?>("CrewId");

                    b.Property<int>("Position");

                    b.Property<int>("Pri");

                    b.Property<int>("PriMax");

                    b.HasKey("CrewAthleteId");

                    b.HasIndex("AthleteId");

                    b.HasIndex("CrewId");

                    b.ToTable("CrewAthlete");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.CrewAward", b =>
                {
                    b.Property<int>("CrewAwardId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AwardId");

                    b.Property<int?>("CrewId");

                    b.HasKey("CrewAwardId");

                    b.HasIndex("AwardId");

                    b.HasIndex("CrewId");

                    b.ToTable("CrewAward");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Penalty", b =>
                {
                    b.Property<int>("PenaltyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CrewId");

                    b.Property<string>("Reason");

                    b.Property<TimeSpan>("Value");

                    b.HasKey("PenaltyId");

                    b.HasIndex("CrewId");

                    b.ToTable("Penalties");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CrewId");

                    b.Property<TimeSpan>("TimeOfDay");

                    b.Property<int>("TimingPointId");

                    b.HasKey("ResultId");

                    b.HasIndex("CrewId");

                    b.HasIndex("TimingPointId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.TimingPoint", b =>
                {
                    b.Property<int>("TimingPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetitionId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("TimingPointId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("TimingPoints");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Award", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("Awards")
                        .HasForeignKey("CompetitionId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Crew", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("Crews")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.CrewAthlete", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Athlete", "Athlete")
                        .WithMany("Crews")
                        .HasForeignKey("AthleteId");

                    b.HasOne("HeadRaceTimingSite.Models.Crew", "Crew")
                        .WithMany("Athletes")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.CrewAward", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Award", "Award")
                        .WithMany("Crews")
                        .HasForeignKey("AwardId");

                    b.HasOne("HeadRaceTimingSite.Models.Crew", "Crew")
                        .WithMany("Awards")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Penalty", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Crew", "Crew")
                        .WithMany("Penalties")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Result", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Crew", "Crew")
                        .WithMany("Results")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HeadRaceTimingSite.Models.TimingPoint", "TimingPoint")
                        .WithMany("Results")
                        .HasForeignKey("TimingPointId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.TimingPoint", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("TimingPoints")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HeadRaceTimingSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
