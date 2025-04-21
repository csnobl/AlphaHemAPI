using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlphaHemAPI.Data.DTO;

namespace AlphaHemAPI.Controllers
{
    //Author : ALL
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly MunicipalityService municipalityService;

        public MunicipalityController(MunicipalityService municipalityService)
        {
            this.municipalityService = municipalityService;
        }

        // Author : Christoffer
        [HttpGet]
        public async Task<IActionResult> GetAllMunicipalities()
        {
            var municipalities = await municipalityService.GetAllMunicipalitiesAsync();
            return Ok(municipalities);
        }
    }
}
