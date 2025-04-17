namespace AlphaHemAPI.Data.Models
{
    //Author : ALL
    public class Listing
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public int YearBuilt { get; set; }
        public decimal Price { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal YearlyOperatingCost { get; set; }
        public decimal LivingArea { get; set; }
        public decimal SecondaryArea { get; set; }
        public decimal LotArea { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }

        // Enum
        public Category Category { get; set; }

        //Navigation properties
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }
        public int RealtorId { get; set; }
        public Realtor Realtor { get; set; }
    }
}
