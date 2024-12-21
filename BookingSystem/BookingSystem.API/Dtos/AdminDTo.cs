using Microsoft.AspNetCore.Authorization;

namespace BookingSystem.API.Dtos
{
   
    public class AdminDTo
    {
        
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
