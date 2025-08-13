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
    }
}
