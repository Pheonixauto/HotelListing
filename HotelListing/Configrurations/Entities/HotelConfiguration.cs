using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configrurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                 new Hotel
                 {
                     Id = 1,
                     Name = "JW Marriott Hotel HanoiOpens in new window",
                     Address = "8 Do Duc Duc",
                     CountryId = 1,
                     Rating = 5
                 },
                new Hotel
                {
                    Id = 2,
                    Name = "The Myst Dong KhoiOpens in new window",
                    Address = "6-8 Ho Huan Nghiep, District 1 , District 1",
                    CountryId = 2,
                    Rating = 5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Muong Thanh Hotel",
                    Address = "1 Truong Thi, Tp.Vinh",
                    CountryId = 3,
                    Rating = 3
                });
        }
    }
}
