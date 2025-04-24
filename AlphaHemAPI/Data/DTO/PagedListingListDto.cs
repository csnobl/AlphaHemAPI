﻿namespace AlphaHemAPI.Data.DTO
{
    // Author: Christoffer
    public class PagedListingListDto
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public List<ListingListDto> Listings { get; } = new List<ListingListDto>();
    }
}
