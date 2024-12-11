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
                .ForMember(D => D.hall, o => o.MapFrom(S => S.hall.Name))
                .ForMember(D => D.NationalUrl, o => o.MapFrom(s => s.NationalUrl));
      
        }

    }
}
