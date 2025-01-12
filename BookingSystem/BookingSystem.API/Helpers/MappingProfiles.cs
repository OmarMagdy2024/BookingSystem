using AutoMapper;
using BookingSystem.API.Dtos;
using BookingSystem.Core.Models;

namespace BookingSystem.API.Helpers
{
    public class MappingProfiles : Profile
    {
        

        public MappingProfiles()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(d => d.hall, o => o.MapFrom(s => s.hall.Name));
               


        }

    }
}
