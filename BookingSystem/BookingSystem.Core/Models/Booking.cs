using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Models
{
	public class Booking:BaseModel
	{
		public	string CustomerName { get; set; }
        [StringLength(14, MinimumLength = 14, ErrorMessage = "The National ID must be exactly 14 digits.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "The National ID must contain only digits.")]
        public int NationalId { get; set; }
		public IFormFile NationalPicture { get; set; }
		public string NationalUrl { get; set; }
		public Hall hall { get; set; }
		public int hallid { get; set; }
		public DateTime TimeSlot { get; set; }
		public Status Status { get; set; }
	}
}
