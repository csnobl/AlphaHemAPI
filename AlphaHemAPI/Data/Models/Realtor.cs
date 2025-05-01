using Microsoft.AspNetCore.Identity;

namespace AlphaHemAPI.Data.Models
{
    //Author : ALL
    public class Realtor : IdentityUser 
    {
        public Realtor()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }

        // Navigation properties
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
