using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Core.Services.Contract
{
    public interface IAuthService
    {
        Task<string> CreateTokenAsync(AppUser appUser, UserManager<AppUser> userManager);
    }
}
