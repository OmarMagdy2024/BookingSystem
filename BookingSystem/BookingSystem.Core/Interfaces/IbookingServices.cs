using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Models;

namespace BookingSystem.Core.Interfaces
{
    public interface IbookingServices
    {
        IEnumerable<DateTime> GetAvailableDates();
        Booking GetBookingById(int bookingId);
        void CreateBooking(Booking model);
        void CancelBooking(int bookingId);
        Contract GenerateContract(int bookingId);
        void SendBookingConfirmation(int bookingId);
    }
}
