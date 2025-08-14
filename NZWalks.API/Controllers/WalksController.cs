using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        /// <summary>
        /// Adds a new walk
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddWalk")]
        [ValidateModel]
        public async Task<IActionResult> AddWalk(WalkCreateDto dto)
        {

            // map dto to entity
            var walk = mapper.Map<Walk>(dto);
            await walkRepository.AddWalkAsync(walk);
            return Ok(mapper.Map<WalkDto>(walk));

        }

        /// <summary>
        /// Get all walks, including info about difficulty and region
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllWalks")]
        public async Task<IActionResult> GetAllWalks(string? filterOn, string? filterQuery, string? sortBy, bool isAscending)
        {
            List<Walk> walks = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending);
            if (!walks.Any())
            {
                return NotFound("No walks available.");
            }
            return Ok(walks);
        }

        [HttpGet("GetWalkById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Walk? walk = await walkRepository.GetByIdAsync(id);
            if (walk is null)
            {
                return NotFound("No walk found");
            }
            return Ok(walk);
        }

        /// <summary>
        /// Updates a walk
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("UpdateWalk/{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk(Guid id, UpdateWalkDto dto)
        {
            Walk? walk = mapper.Map<Walk>(dto);
            walk = await walkRepository.UpdateWalkAsync(id, walk);
            if (walk is null)
            {
                return NotFound("No walk found.");
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }

        /// <summary>
        /// Deletes a walk
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteWalk/{id}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            Walk? walk = await walkRepository.DeleteWalkAsync(id);
            if (walk is null)
            {
                return NotFound("No walk found.");
            }
            return Ok(mapper.Map<WalkDto>(walk));
        }
    }
}
