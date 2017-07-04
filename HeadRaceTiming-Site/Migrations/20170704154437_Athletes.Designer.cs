using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HeadRaceTimingSite.Models;

namespace HeadRaceTimingSite.Migrations
{
    [DbContext(typeof(TimingSiteContext))]
    [Migration("20170704154437_Athletes")]
    partial class Athletes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeadRaceTimingSite.Models.Athlete", b =>
                {
                    b.Property<int>("AthleteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AthleteId");

                    b.ToTable("Athlete");
                });

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

            modelBuilder.Entity("HeadRaceTimingSite.Models.CrewAthlete", b =>
                {
                    b.Property<int>("CrewAthleteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AthleteId");

                    b.Property<int?>("CrewId");

                    b.Property<int>("Position");

                    b.HasKey("CrewAthleteId");

                    b.HasIndex("AthleteId");

                    b.HasIndex("CrewId");

                    b.ToTable("CrewAthlete");
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

            modelBuilder.Entity("HeadRaceTimingSite.Models.Crew", b =>
                {
                    b.HasOne("HeadRaceTimingSite.Models.Competition", "Competition")
                        .WithMany("Crews")
                        .HasForeignKey("CompetitionId");
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
