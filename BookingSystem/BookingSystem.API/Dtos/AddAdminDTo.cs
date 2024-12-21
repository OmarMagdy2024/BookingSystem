using Microsoft.AspNetCore.Authorization;

namespace BookingSystem.API.Dtos
{
    public class AddAdminDTo
    {
        public class AddAdminDTO
        {
            public string UserId { get; set; } 
            public string Role { get; set; } 
        }

    }
}
