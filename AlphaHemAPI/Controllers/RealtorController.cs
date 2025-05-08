using System.Net;
using AlphaHemAPI.Constants;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Register([FromBody] RealtorRegisterDto registerDto)
        {
            var result = await realtorService.RegisterRealtorAsync(registerDto);
            if (!result)
                return BadRequest("Email is already taken or agency does not exist.");
            return StatusCode(StatusCodes.Status201Created);
        }

        //Author: Christoffer
        // Co-author: Conny
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRealtor(string id, [FromBody] RealtorUpdateDto realtorUpdateDto)
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
        public async Task<IActionResult> GetRealtorById(string id)
        {
            var realtor = await realtorService.GetRealtorByIdAsync(id);
            if (realtor == null)
                return NotFound("Realtor not found.");
            return Ok(realtor);
        }

        //Author : ALL
        [HttpPut("ApproveRealtor/{id}")]
        [Authorize(Roles = ApiRoles.RealtorAdmin)]
        public async Task<IActionResult> ApproveEmailForRealtor(string id)
        {
            var adminId = User.FindFirst(CustomClaimTypes.Uid)?.Value;

            var result = await realtorService.ApproveEmailForRealtorAsync(id, adminId);
            if (!result)
                return NotFound("Realtor not found or already approved.");

            return NoContent();
        }

        // Author: Conny
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiRoles.RealtorAdmin)]
        public async Task<IActionResult> DeleteRealtor(string id)
        {
            var adminId = User.FindFirst(CustomClaimTypes.Uid)?.Value;
            var response = await realtorService.DeleteRealtorAsync(id, adminId);
            if (!response.Success)
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return NotFound(response);
                    case HttpStatusCode.BadRequest:
                        return BadRequest(response);
                    case HttpStatusCode.InternalServerError:
                        return StatusCode(500, response);
                }
            return NoContent();
        }
    }
}
