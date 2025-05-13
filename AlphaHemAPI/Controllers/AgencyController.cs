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
    public class AgencyController : ControllerBase
    {
        private readonly AgencyService agencyService;

        public AgencyController(AgencyService agencyService)
        {
            this.agencyService = agencyService;
        }

        //Author: Mattias
        // Co-author: ALL
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgency(int id)
        {
            var response = await agencyService.GetAgencyById(id);

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

        //Author: Mattias
        // Co-author: ALL
        [HttpGet]
        public async Task<ActionResult<List<AgencyWithRealtorsDto>>> GetAllAgencies()
        {
            var response = await agencyService.GetAllAgencies();

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response.Data);
        }

        //Author: Mattias
        [HttpPut("{id}")]
        [Authorize(Roles = ApiRoles.RealtorAdmin)]
        public async Task<IActionResult> UpdateAgency([FromBody] AgencyUpdateDto agency)
        {
            var adminRealtorId = User.FindFirst(CustomClaimTypes.Uid)?.Value;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await agencyService.UpdateAgency(adminRealtorId,agency);

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

    }
}
