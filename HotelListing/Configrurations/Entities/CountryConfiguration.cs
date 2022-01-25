using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelListing.Configrurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {     

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Ha Noi",
                    ShortName = "HN"

                },
               new Country
               {
                   Id = 2,
                   Name = "TP.HCM",
                   ShortName = "SG"

               },
               new Country
               {
                   Id = 3,
                   Name = "Nghe An",
                   ShortName = "NA"

               }
               );
        }
    }
}
