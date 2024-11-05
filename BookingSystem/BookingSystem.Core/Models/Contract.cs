using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Models
{
	public class Contract:BaseModel
	{
		public Booking booking {  get; set; }
		public int bookingid { get; set; }
		public string BrideName { get; set; }
		public string GroomName { get; set; }
		decimal Amount { get; set; }
		public Status Status { get; set; }
	}
}
