﻿namespace BookingSystem.Core.Models
{
	public class Package:BaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}