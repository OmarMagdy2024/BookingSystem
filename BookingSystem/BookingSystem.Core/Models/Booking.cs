using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Models
{
	public class Booking:BaseModel
	{
		string CustomerName { get; set; }
		public int NationalId { get; set; }
		public IFormFile NationalPicture { get; set; }
		public string NationalUrl { get; set; }
		public Hall hall { get; set; }
		public int hallid { get; set; }
		public DateTime TimeSlot { get; set; }
		public Status Status { get; set; }
	}
}
