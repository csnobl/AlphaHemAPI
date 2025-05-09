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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgency(int id)
        {
            try
            {
                var agency = await agencyService.GetAgencyById(id);
                if (agency == null)
                {
                    return NotFound();
                }
                return Ok(agency);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Author: Mattias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyWithRealtorsDto>>> GetAllAgencies()
        {
            var agencies = await agencyService.GetAllAgencies();
            
            return Ok(agencies);
            
        }
    }
}
