using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<IActionResult> GetAllListings()
        {
            var listings = await listingService.GetAllListingsAsync();
            return Ok(listings);
        }

        // Author : Smilla
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListingDetails(int id)
        {
            var listingDetails = await listingService.GetListingDetailsAsync(id);

            if (listingDetails == null)
            {
                return NotFound();
            }

            return Ok(listingDetails);
        }

        // Author: Conny
        [HttpPost]
        public async Task<IActionResult> CreateListing([FromBody] ListingCreateDto listingCreateDto)
        {
            if (listingCreateDto.Images == null || listingCreateDto.Images.Count == 0 || listingCreateDto.Images.Count > 40)
                return BadRequest("Listings require between 1 and 40 images.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await listingService.AddListingAsync(listingCreateDto);

            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating listing.");

            return StatusCode(StatusCodes.Status201Created);
        }

        // Author: Conny
        [HttpPut]
        public async Task<IActionResult> UpdateListing(int id, [FromBody] ListingUpdateDto listingUpdateDto)
        {
            if (listingUpdateDto.Images == null || listingUpdateDto.Images.Count == 0 || listingUpdateDto.Images.Count > 40)
                return BadRequest("Listings require between 1 and 40 images.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await listingService.UpdateListingAsync(id, listingUpdateDto);

            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating listing.");

            return StatusCode(StatusCodes.Status201Created);
        }
        
        // Author: Niklas
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            var result = await listingService.DeleteListingAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
