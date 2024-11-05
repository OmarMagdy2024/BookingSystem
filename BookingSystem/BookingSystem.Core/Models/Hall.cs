using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Models
{
	public class Hall:BaseModel
	{
		public string Name { get; set; }
		public int Capacity { get; set; }
		public string Address { get; set; }
		public ICollection<Package> package  { get; set; }= new HashSet<Package>();
		public IFormFile Image { get; set; }
		public string ImageUrl { get; set; }
		public decimal price { get; set; }
	}
}
