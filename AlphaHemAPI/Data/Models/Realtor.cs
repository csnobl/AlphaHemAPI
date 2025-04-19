namespace AlphaHemAPI.Data.Models
{
    //Author : ALL
    public class Realtor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Author : Niklas
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }

        // Navigation properties

        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
