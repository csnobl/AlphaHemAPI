using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
