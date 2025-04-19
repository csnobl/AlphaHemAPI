using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHemAPI.Controllers
{
    //Author : ALL
    [Route("api/[controller]")]
    [ApiController]
    public class RealtorController : ControllerBase
    {
        private readonly RealtorService realtorService;

        public RealtorController(RealtorService realtorService)
        {
            this.realtorService = realtorService;
        }

        // Author : Niklas
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RealtorRegisterDto registerDto)
        {
            var result = await realtorService.RegisterRealtorAsync(registerDto);
            if (!result)
                return BadRequest("Email is already taken or agency does not exist.");
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
