using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.DTO
{
    // Author : Smilla
    public class ListingListDto
    {
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Municipality { get; set; }
        public string RealtorFullName { get; set; }
    }
}
