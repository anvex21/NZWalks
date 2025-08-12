 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            List<Region> regionsEntity = _context.Regions.ToList();
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
        public IActionResult GetById(Guid id) {
            Region? region = _context.Regions.FirstOrDefault(r => r.Id == id);
            if(region is null)
            {
                return NotFound("No region with such id found.");
            }
            var dto = new RegionDto()
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
        public IActionResult AddRegion(RegionCreateDto dto)
        {
            // map dto to entity
            var region = new Region
            {
                Code = dto.Code,
                Name = dto.Name,
                RegionImageUrl = dto.RegionImageUrl
            };
            _context.Regions.Add(region);
            _context.SaveChanges();
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }; 
            return CreatedAtAction(nameof(GetById),new {id = regionDto .Id}, regionDto);
        }
    }
}
