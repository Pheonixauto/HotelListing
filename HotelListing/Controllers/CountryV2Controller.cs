using HotelListing.Datas;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Models
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/country")]
    [ApiController]
    public class CountryV2Controller : Controller
    {

        private DataBaseContext _dataBaseContext;


        public CountryV2Controller (DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {

            return Ok(_dataBaseContext.Countries);
        }

       
    }
}
