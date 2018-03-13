using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HeadRaceTimingSite.Models
{
    public class TimingSiteContext : IdentityDbContext<ApplicationUser>
    {
        public TimingSiteContext(DbContextOptions<TimingSiteContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.Crews)
                .WithOne(c => c.Competition)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Competition>()
                .HasMany(c => c.TimingPoints)
                .WithOne(s => s.Competition)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Crew>()
                .HasMany(c => c.Results)
                .WithOne(r => r.Crew)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimingPoint>()
                .HasMany(s => s.Results)
                .WithOne(r => r.TimingPoint)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<TimingPoint> TimingPoints { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
    }
}
