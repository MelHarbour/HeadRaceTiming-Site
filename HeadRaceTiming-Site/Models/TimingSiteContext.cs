using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HeadRaceTimingSite.Models
{
    public class TimingSiteContext : DbContext
    {
        public TimingSiteContext(DbContextOptions<TimingSiteContext> options) : base(options)
        { }

        public DbSet<Crew> Crews { get; set; }
    }
}
