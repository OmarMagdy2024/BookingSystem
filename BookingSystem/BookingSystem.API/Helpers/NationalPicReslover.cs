using AutoMapper;
using BookingSystem.API.Dtos;
using BookingSystem.Core.Models;



namespace BookingSystem.API.Helpers
{
    public class NationalPicReslover : IValueResolver<Booking, BookingDto , string>
    {
        private readonly IConfiguration _configuration;

        public NationalPicReslover( IConfiguration configuration )
        {
           _configuration = configuration;
        }

        public string Resolve(Booking source, BookingDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.NationalUrl))
            { 
                return $"{_configuration["ApiBaseUrl"]}/{source.NationalUrl}";
            }
            return string.Empty;
        }
    }
}
