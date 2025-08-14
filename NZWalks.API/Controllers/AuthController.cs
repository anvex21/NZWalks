using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            IdentityUser identityUser = new IdentityUser
            {
                UserName = dto.Username,
                Email = dto.Username
            };
            IdentityResult identityResult = await userManager.CreateAsync(identityUser, dto.Password);
            if (identityResult.Succeeded)
            {
                // Add roles to this user
                if(dto.Roles is not null && dto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, dto.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User was registered. Please log in!");
                    }
                }
                
            }
            return BadRequest("Something went wrong.");
        } 
    }
}
