namespace AlphaHemAPI.Data.DTO
{
    // Author: Christoffer
    public class PagedListingListDto
    {
        public int TotalCount { get; set; }
        public List<ListingListDto> Listings { get; } = new List<ListingListDto>();
    }
}
