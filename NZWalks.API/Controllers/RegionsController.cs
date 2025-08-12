 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRegions")]
        public async Task<IActionResult> GetAll()
        {
            //List<Region> regionsEntity = await _context.Regions.ToList(); when not using await 
            List<Region> regionsEntity = await _context.Regions.ToListAsync();
            List<RegionDto> dto = new List<RegionDto>();
            foreach(var region in regionsEntity)
            {
                dto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                }); 
            }
            if(!dto.Any())
            {
                return NotFound("No regions found.");
            }
            return Ok(dto);
        }

        /// <summary>
        /// Gets a region by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetRegionById/{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            // Region region = await _context.Regions.FirstOrDefault(r => r.Id == id); when not using await
            Region region = await _context.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if(region is null)
            {
                return NotFound("No region with such id found.");
            }
            RegionDto dto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(dto);
        }

        /// <summary>
        /// Adds a new region
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRegion")]
        public async Task<IActionResult> AddRegion(RegionCreateDto dto)
        {
            // map dto to entity
            var region = new Region
            {
                Code = dto.Code,
                Name = dto.Name,
                RegionImageUrl = dto.RegionImageUrl
            };
            // _context.Regions.Add(region); when not using await
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }; 
            return CreatedAtAction(nameof(GetById),new {id = regionDto .Id}, regionDto);
        }

        /// <summary>
        /// Updates a region
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateRegion/{id}")]
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateRegionDto dto)
        {
            Region region = await _context.Regions.FirstOrDefaultAsync(x  => x.Id == id);
            if(region is null)
            {
                return NotFound("No region found.");
            }
            region.Code = dto.Code;
            region.Name = dto.Name;
            region.RegionImageUrl = dto.RegionImageUrl;
            await _context.SaveChangesAsync();
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok();
        }

        
        /// <summary>
        /// Deletes a region
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRegion/{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            Region region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region is null)
            {
                return NotFound("No such region.");
            }
            // no async method for remove
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
