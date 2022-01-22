using AutoMapper;
using HotelListing.Models;

namespace HotelListing.Configruations
{
    public class MapperInitializi: Profile
    {
        public MapperInitializi()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, HotelDTO>().ReverseMap();
            CreateMap<Country, CreateHotelDTO>().ReverseMap();

        }
    }
}
