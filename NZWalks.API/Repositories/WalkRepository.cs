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

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk is null) return null;
            context.Walks.Remove(existingWalk);
            await context.SaveChangesAsync();
            return existingWalk;

        }

        public async Task<List<Walk>> GetAllAsync()
        {
            // return await context.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync(); -> same thing
            return await context.Walks.
                Include("Difficulty").
                Include("Region").
                ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await context.Walks.
                Include("Difficulty").
                Include("Region").
                FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk is null) {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;
            await context.SaveChangesAsync();
            return existingWalk;
        }
    }
}
