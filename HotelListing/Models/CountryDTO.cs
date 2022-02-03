﻿using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CountryDTO : CreateCountryDTO
    {

        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }  
    }

    public class CreateCountryDTO
    {

      
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name Is Too Long")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = " Short Country Name Is Too Long")]
        public string ShortName { get; set; }= string.Empty;
    }
    public class HotelCountryDTO
    {
        public string NameCountry { get; set; } = String.Empty;
        public IList<string> NameHotel { get; set; } 
    }
}
