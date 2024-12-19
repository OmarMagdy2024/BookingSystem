﻿using System.ComponentModel.DataAnnotations;

namespace BookingSystem.API.Dtos
{
    public class RegisterDTo
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[?= [A-Za-z])](?=\dX?= [@$!%#?&]][A-Za-z\d@$!%*#?&]{8}$", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
    }
}
