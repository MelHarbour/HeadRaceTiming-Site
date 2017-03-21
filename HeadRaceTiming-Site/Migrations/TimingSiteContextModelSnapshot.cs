﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HeadRaceTimingSite.Models;

namespace HeadRaceTimingSite.Migrations
{
    [DbContext(typeof(TimingSiteContext))]
    partial class TimingSiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeadRaceTimingSite.Models.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Crew", b =>
                {
                    b.Property<int>("CrewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetitionId");

                    b.Property<string>("Name");

                    b.Property<int>("StartNumber");

                    b.HasKey("CrewId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CrewId");

                    b.Property<int>("SectionId");

                    b.Property<TimeSpan>("TimeOfDay");

                    b.HasKey("ResultId");

                    b.HasIndex("CrewId");

                    b.HasIndex("SectionId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetitionId");

                    b.HasKey("SectionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Crew", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("Crews")
                        .HasForeignKey("CompetitionId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Result", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Crew", "Crew")
                        .WithMany("Results")
                        .HasForeignKey("CrewId");

                    b.HasOne("HeadRaceTimingSite.Models.Section", "Section")
                        .WithMany("Results")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.Section", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("Sections")
                        .HasForeignKey("CompetitionId");
                });
        }
    }
}
