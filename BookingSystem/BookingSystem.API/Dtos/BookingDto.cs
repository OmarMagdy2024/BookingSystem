using BookingSystem.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.API.Dtos
{
    public class BookingDto
    {
        public string CustomerName { get; set; }
     
        public int NationalId { get; set; }
        public IFormFile NationalUrl { get; set; }
        public string hall { get; set; }
        public int hallid { get; set; }
        public DateTime TimeSlot { get; set; }
        public string Status { get; set; }
    }
}
