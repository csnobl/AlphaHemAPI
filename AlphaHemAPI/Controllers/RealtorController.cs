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

        //Author: Christoffer
        // Co-author: ALL
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRealtor(string id, [FromBody] RealtorUpdateDto realtorUpdateDto)
        {
            var userId = User.FindFirst(CustomClaimTypes.Uid)?.Value;
            if (!string.Equals(userId, id))
                return StatusCode(StatusCodes.Status403Forbidden, "Du har inte behörighet att redigera denna mäklare.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await realtorService.UpdateRealtorAsync(id, realtorUpdateDto);

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                default:
                    return NoContent();
            }
        }

        // //Author : Dominika
        [HttpGet]
        public async Task<ActionResult<List<RealtorDto>>> GetAllRealtors()
        {
            var realtors = await realtorService.GetAllRealtorsAsync();
            return Ok(realtors);
        }

        //Author : Smilla
        // Co-author: ALL
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealtorById(string id)
        {
            var response = await realtorService.GetRealtorByIdAsync(id);
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                default:
                    return Ok(response.Data);
            }
        }

        //Author : ALL
        [HttpPut("ApproveRealtor/{id}")]
        [Authorize(Roles = ApiRoles.RealtorAdmin)]
        public async Task<IActionResult> ApproveEmailForRealtor(string id)
        {
            var adminId = User.FindFirst(CustomClaimTypes.Uid)?.Value;
            var response = await realtorService.ApproveEmailForRealtorAsync(id, adminId);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Forbidden:
                    return StatusCode(StatusCodes.Status403Forbidden, response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(500, response);
                default:
                    return NoContent();
            }
        }

        // Author: Conny
        // Co-author: ALL
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiRoles.RealtorAdmin)]
        public async Task<IActionResult> DeleteRealtor(string id)
        {
            var adminId = User.FindFirst(CustomClaimTypes.Uid)?.Value;
            var response = await realtorService.DeleteRealtorAsync(id, adminId);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Forbidden:
                    return StatusCode(StatusCodes.Status403Forbidden, response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(500, response);
                default:
                    return NoContent();
            }
        }
    }
}
