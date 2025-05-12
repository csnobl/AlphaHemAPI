using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlphaHemAPI.Data.DTO;
using System.Net;

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
            var response = await municipalityService.GetAllMunicipalitiesAsync();

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response.Data);
        }
    }
}
