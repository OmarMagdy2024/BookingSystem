using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Models
{
	public enum Status
	{
		[EnumMember(Value = "Success")]
		Success,
		[EnumMember(Value = "pending")]
		pending,
		[EnumMember(Value = "Payed")]
		Payed
	}
}
