using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
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


        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            IdentityUser? user = await userManager.FindByEmailAsync(dto.Username);
            if (user is not null) {
                bool checkPassword = await userManager.CheckPasswordAsync(user, dto.Password);
                if (checkPassword)
                {
                    IList<string> roles = await userManager.GetRolesAsync(user);
                    if(roles is not null)
                    {
                        //Create a token
                        string jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        LoginResponseDto response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }
            }
            return BadRequest("Username or password incorrect.");
        }
    }
}
