using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllWalks()
        {
            List<Walk> walks = await walkRepository.GetAllAsync();
            if (!walks.Any())
            {
                return NotFound("No walks available.");
            }
            return Ok(walks);
        }

        [HttpGet("GetWalkById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walk = await walkRepository.GetByIdAsync(id);
            if(walk is null)
            {
                return NotFound("No walk found");
            }
            return Ok(walk);
        }

        [HttpPut("UpdateWalk/{id}")]
        public async Task<IActionResult> UpdateWalk(Guid id, UpdateWalkDto dto)
        {
            var walk = mapper.Map<Walk>(dto);
            walk = await walkRepository.UpdateWalkAsync(id, walk);
            if (walk is null)
            {
                return NotFound("No walk found.");
            }
            return Ok(mapper.Map<WalkDto>(walk));

        }
    }
}
