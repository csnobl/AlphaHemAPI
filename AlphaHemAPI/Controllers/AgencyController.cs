using System.Net;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Services;
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
    }
}
