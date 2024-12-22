using AutoMapper;
using BookingSystem.API.Dtos;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
   
    public class BookingController : BaseApiController
    {
        private readonly IbookingServices _bookingServices;
        private readonly IMapper _mapper;

        public BookingController(IbookingServices bookingServices ,IMapper mapper)
        {
            _bookingServices = bookingServices;
            _mapper = mapper;
        }

        //[HttpPost("AddBooking")]
        //public Task<ActionResult<Booking>> AddBooking(BookingDto bookingDto)
        //{
        //    _bookingServices.CreateBooking(bookingDto);

        //}
    }
}
