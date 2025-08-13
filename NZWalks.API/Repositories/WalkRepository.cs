using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext context;

        public WalkRepository(NZWalksDbContext context)
        {
            this.context = context;
        }
        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            await context.Walks.AddAsync(walk);
            await context.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            // return await context.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync(); -> same thing
            return await context.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }
    }
}
