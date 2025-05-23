﻿using AlphaHemAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlphaHemAPI.Data
{
    //Author : ALL
    public class AlphaHemAPIDbContext : IdentityDbContext<Realtor>
    {
        public AlphaHemAPIDbContext(DbContextOptions<AlphaHemAPIDbContext> options) : base(options)
        {   
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
    }

    
}
