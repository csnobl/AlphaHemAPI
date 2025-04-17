namespace AlphaHemAPI.Data.Models
{
    public class Municipality
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public List<Listing> Listings { get; set; }
    }
}
