using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<CountryController> ilogger;
        private readonly IMapper imapper ;

        public CountryController(IUnitOfWork unitofWork, ILogger<CountryController> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetCountries()
        {
            try
            {
                var uni = await iunitOfWork.Countries.GetAll();
                var results=imapper.Map<List<CountryDTO>>(uni);
                return Ok(results);
            }
            catch (Exception x)
            {
                ilogger.LogError($"wrong");
                return StatusCode(500, "try again");
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry (int id)
        {
            try
            {
                var uniId  = await iunitOfWork.Countries.Get(q=>q.Id == id, new List<string>{"Hotels"});
                var result = imapper.Map<CountryDTO>(uniId);
                return Ok(result);
            }
            catch (Exception x)
            {
                ilogger.LogError($"wrong");
                return StatusCode(500, "try again");
            }

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCountrybyName(string name)
        {
            try
            {
                var uniId = await iunitOfWork.Countries.Get(q => q.Name == name, new List<string>{ "Hotels" });
                var result = imapper.Map<CountryDTO>(uniId);
                return Ok(result);
            }
            catch (Exception x)
            {
                ilogger.LogError($"wrong");
                return StatusCode(500, "try again");
            }

        }
    }
}
