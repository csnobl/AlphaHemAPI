using AlphaHemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaHemAPI.Data
{
    public class AlphaHemAPIDbContext : DbContext
    {
        public AlphaHemAPIDbContext() : base()
        {   
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
    }

    
}
