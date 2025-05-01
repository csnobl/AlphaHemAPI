using System.ComponentModel.DataAnnotations;

namespace AlphaHemAPI.Data.DTO
{
    //Author: Christoffer
    // Co-author: Conny
    public class RealtorUpdateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
