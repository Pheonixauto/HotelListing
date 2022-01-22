using HotelListing.Models;
using Microsoft.EntityFrameworkCore;


namespace HotelListing.Datas
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
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
            modelBuilder.Entity<Hotel>().HasData(

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
                }
            );
        }




    }
}
