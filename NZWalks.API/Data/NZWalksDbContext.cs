using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
        }
        /// <summary>
        /// DbSet Difficulties
        /// </summary>
        public DbSet<Difficulty> Difficulties { get; set; }
        /// <summary>
        /// DbSet Regions
        /// </summary>
        public DbSet<Region> Regions { get; set; }
        /// <summary>
        /// DbSet Walks
        /// </summary>
        public DbSet<Walk> Walks { get; set; }
    }
}
