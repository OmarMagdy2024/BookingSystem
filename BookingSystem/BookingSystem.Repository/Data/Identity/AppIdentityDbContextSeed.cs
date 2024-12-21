using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Repository.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed",
                    Email = "Ahmed.gamal@inalio.com",
                    UserName = "ahmed.gamal",
                    PhoneNumber = "1234567890"
                };
                await _userManager.CreateAsync(user, "pa$$sw0rd");
            }
        }
    }
}
