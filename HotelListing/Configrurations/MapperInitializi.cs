using AutoMapper;
using HotelListing.Datas;
using HotelListing.Models;

namespace HotelListing.Configruations
{
    public class MapperInitializi: Profile
    {
        public MapperInitializi()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
