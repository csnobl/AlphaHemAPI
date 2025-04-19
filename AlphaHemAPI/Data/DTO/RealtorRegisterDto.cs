﻿using System.ComponentModel.DataAnnotations;

namespace AlphaHemAPI.Data.DTO
{
    public class RealtorRegisterDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public int AgencyId { get; set; }

    }
}
