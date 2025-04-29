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

        //Author: Christoffer
        // Co-author: Conny
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRealtor(int id, [FromBody] RealtorUpdateDto realtorUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await realtorService.UpdateRealtorAsync(id, realtorUpdateDto);

            if (!result)
                return NotFound("Realtor not found or update failed.");

            return NoContent();
        }

        //Author : Dominika
        [HttpGet]
        public async Task<ActionResult<List<RealtorDto>>> GetAllRealtors()
        {
            var realtors = await realtorService.GetAllRealtorsAsync();
            return Ok(realtors);
        }

        //Author : Smilla
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealtorById(int id)
        {
            var realtor = await realtorService.GetRealtorByIdAsync(id);
            if (realtor == null)
                return NotFound("Realtor not found.");
            return Ok(realtor);
        }
    }
}
