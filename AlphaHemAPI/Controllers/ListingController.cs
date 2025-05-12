using System.Net;
using AlphaHemAPI.Constants;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AlphaHemAPI.Controllers
{
    //Author : ALL
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly ListingService listingService;

        public ListingController(ListingService listingService)
        {
            this.listingService = listingService;
        }

        // Author : Smilla
        // Co-author: Christoffer
        [HttpGet]
        public async Task<IActionResult> GetPagedListings(
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize,
            [FromQuery] string? municipality = null,
            [FromQuery] string? category = null,
            [FromQuery] string? sortBy = null)
        {
            var response = await listingService.GetPagedListingsAsync(
                pageIndex,
                pageSize,
                municipality,
                category,
                sortBy);

            // Author: ALL
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response.Data);
        }

        // Author : Smilla
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListingDetails(int id)
        {
            var response = await listingService.GetListingDetailsAsync(id);

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

        // Author: Conny
        // Co-author: ALL
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateListing([FromBody] ListingCreateDto listingCreateDto)
        {
            if (listingCreateDto.Images == null || listingCreateDto.Images.Count == 0 || listingCreateDto.Images.Count > 40)
                return BadRequest("Bostäder måste inkludera minst en bild och högst fyrtio bilder.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await listingService.AddListingAsync(listingCreateDto);

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                default:
                    return StatusCode(StatusCodes.Status201Created, response);
            }
        }

        // Author: Conny
        // Co-author: ALL
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateListing(int id, [FromBody] ListingUpdateDto listingUpdateDto)
        {
            var userId = User.FindFirst(CustomClaimTypes.Uid)?.Value;
            if (!string.Equals(userId, listingUpdateDto.RealtorId))
                return StatusCode(StatusCodes.Status403Forbidden, "Du har inte behörighet att redigera denna bostad.");

            if (listingUpdateDto.Images == null || listingUpdateDto.Images.Count == 0 || listingUpdateDto.Images.Count > 40)
                return BadRequest("Bostäder måste inkludera minst en bild och högst fyrtio bilder.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await listingService.UpdateListingAsync(id, listingUpdateDto);

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                default:
                    return NoContent();
            };
        }

        // Author: Niklas
        // Co-author: ALL
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var realtorResponse = await listingService.GetListingDetailsAsync(id);
            if (realtorResponse.Data == null)
                return NotFound(realtorResponse);
            var realtorId = realtorResponse.Data.Realtor.Id;

            var userId = User.FindFirst(CustomClaimTypes.Uid)?.Value;

            if (!string.Equals(userId, realtorId))
                return StatusCode(StatusCodes.Status403Forbidden, "Du har inte behörighet att ta bort denna bostad.");

            var response = await listingService.DeleteListingAsync(id);

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

        // Author: Conny
        // Co-author: ALL
        [HttpGet("realtor/{id}")]
        public async Task<IActionResult> GetListingsByRealtor(string id)
        {
            var response = await listingService.GetListingsByRealtorAsync(id);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response.Data);
        }
    }
}
