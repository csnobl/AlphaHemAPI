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
    }
}
