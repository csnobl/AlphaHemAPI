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
            var agency = await agencyService.GetAgencyById(id);
            if (agency == null)
            {
                return NotFound();
            }
            return Ok(agency);
        }

        //Author: Mattias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyWithRealtorsDto>>> GetAllAgencies()
        {
            var agencies = await agencyService.GetAllAgencies();
            if (agencies == null)
            {
                return NotFound();
            }
            return Ok(agencies);
        }
    }
}
