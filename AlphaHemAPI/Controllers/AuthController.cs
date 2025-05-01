using AlphaHemAPI.Data;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AlphaHemAPI.Controllers
{
    //Author : ALL
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Realtor> userManager;
        private readonly AuthService authService;

        public AuthController(UserManager<Realtor> userManager, AuthService authService)
        {
            this.userManager = userManager;
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RealtorRegisterDto realtor)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await authService.Register(realtor);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            return Accepted();
        }

        [HttpPost]
        [Route("login")]

        public async Task<ActionResult<AuthResponse>> Login([FromBody] RealtorLoginDto login)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var result = await authService.Login(login);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }

            var reponse = new AuthResponse
            {
                UserId = result.UserId,
                Email = login.Email,
                Token = result.Token
            };

            return Ok(reponse);
        }
    }
}
