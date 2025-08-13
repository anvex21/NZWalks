using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;
        public RegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            Region? region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region is null) {
                return null;
            }
            _context.Regions.Remove(region);
            _context.SaveChangesAsync();
            return region;

        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            Region? existingRegion = _context.Regions.FirstOrDefault(x => x.Id == id);
            if (existingRegion is null) {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            await _context.SaveChangesAsync();
            return existingRegion;
        }
    }
}
