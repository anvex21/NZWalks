using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {

            _context = context;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns></returns>
      
        [HttpGet("GetAllRegions")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //List<Region> regionsEntity = await _context.Regions.ToList(); when not using await 
            List<Region> regionsEntity = await _regionRepository.GetAllAsync();
            List<RegionDto> dto = _mapper.Map<List<RegionDto>>(regionsEntity);
            if (!dto.Any())
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
        [Authorize(Roles = "Reader")]
        [HttpGet("GetRegionById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            // Region region = await _context.Regions.FirstOrDefault(r => r.Id == id); when not using await
            Region region = await _regionRepository.GetByIdAsync(id);
            if (region is null)
            {
                return NotFound("No region with such id found.");
            }
            RegionDto dto = _mapper.Map<RegionDto>(region);
            return Ok(dto);
        }

        /// <summary>
        /// Adds a new region
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRegion")]
        [Authorize(Roles = "Writer")]
        [ValidateModel]

        public async Task<IActionResult> AddRegion(RegionCreateDto dto)
        {
            // map dto to entity
            Region region = _mapper.Map<Region>(dto);
            // _context.Regions.Add(region); when not using await
            region = await _regionRepository.AddRegionAsync(region);
            await _context.SaveChangesAsync();
            // map entity to dto
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        /// <summary>
        /// Updates a region
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpPut("UpdateRegion/{id}")]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateRegionDto dto)
        {
            Region? region = _mapper.Map<Region>(dto);
            region = await _regionRepository.UpdateAsync(id, region);
            if (region is null)
            {
                return NotFound("No region found.");
            }
            var regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }



        /// <summary>
        /// Deletes a region
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete("DeleteRegion/{id}")]
        [Authorize(Roles = "Writer")]
        // for both roles - [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            // no async method for remove, just named it like that in the repository 
            Region region = await _regionRepository.DeleteRegionAsync(id);
            if (region is null)
            {
                return NotFound("No such region.");
            }
            // no async method for remove
            return Ok();

        }

    }
}
