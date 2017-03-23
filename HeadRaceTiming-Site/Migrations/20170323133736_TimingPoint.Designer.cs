using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HeadRaceTimingSite.Models;

namespace HeadRaceTimingSite.Migrations
{
    [DbContext(typeof(TimingSiteContext))]
    [Migration("20170323133736_TimingPoint")]
    partial class TimingPoint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("TimingPointId");

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

                    b.HasKey("TimingPointId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("TimingPoints");
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

                    b.HasOne("HeadRaceTimingSite.Models.TimingPoint", "TimingPoint")
                        .WithMany("Results")
                        .HasForeignKey("TimingPointId");
                });

            modelBuilder.Entity("HeadRaceTimingSite.Models.TimingPoint", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("TimingPoints")
                        .HasForeignKey("CompetitionId");
                });
        }
    }
}
