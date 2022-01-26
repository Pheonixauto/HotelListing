using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper imapper;

        public CountryController(IUnitOfWork unitofWork, ILogger<CountryController> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var uni = await iunitOfWork.Countries.GetAll();
                var results = imapper.Map<List<CountryDTO>>(uni);
                return Ok(results);
            }
            catch (Exception x)
            {
                ilogger.LogError($"wrong");
                return StatusCode(500, "try again");
            }

        }


        //[Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountryById (int id)
        {
            try
            {
                var uniId = await iunitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var result = imapper.Map<CountryDTO>(uniId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"wrong");
                return StatusCode(500, "try again");
            }

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCountrybyName(string name)
        {
            try
            {
                var uniId = await iunitOfWork.Countries.Get(q => q.Name == name, new List<string> { "Hotels" });
                var result = imapper.Map<CountryDTO>(uniId);
                return Ok(result);
            }
            catch (Exception x)
            {
                ilogger.LogError($"wrong");
                return StatusCode(500, "try again");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] CreateCountryDTO createCountryDTO)
        {
            if (!ModelState.IsValid)
            {
                ilogger.LogError($"Invaild POST attempt in {nameof(PostCountry)}");
                return BadRequest(ModelState);
            }
            try
            {
                var country = imapper.Map<Country>(createCountryDTO);
                await iunitOfWork.Countries.Insert(country);
                await iunitOfWork.Save();
                return Ok(country);

            }
            catch (Exception e)
            {

                ilogger.LogError(e, $"wrong");
                return StatusCode(500, "try again");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutCountry(int id, [FromBody] CreateCountryDTO createCountryDTO)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var country = await iunitOfWork.Countries.Get(q => q.Id == id);
                if (country == null)
                {
                    ilogger.LogError($"Invaild PUT attempt in {nameof(PutCountry)}");
                    return BadRequest(ModelState);
                }
                imapper.Map(createCountryDTO, country);
                iunitOfWork.Countries.Update(country);
                await iunitOfWork.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                ilogger.LogError(e, $"Something Wrong {nameof(PutCountry)}");
                return StatusCode(500);

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var country = await iunitOfWork.Countries.Get(q => q.Id == id);
                await iunitOfWork.Countries.Delete(id);
                await iunitOfWork.Save();
                return new JsonResult($"Delete Success {id} ");

            }
            catch (Exception ex)
            {
                ilogger.LogError(ex, $"Something Wrong {nameof(DeleteCountry)}");
                return StatusCode(500);

            }
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteCountryByName(string name)
        {
            if (!ModelState.IsValid)
            {

            }
            try
            {
                var country = await iunitOfWork.Countries.Get(q => q.Name == name);
                //var countryId = country.Id;
                //await iunitOfWork.Countries.Delete(countryId);  
                
                await iunitOfWork.Countries.DeleteByName(name);


                await iunitOfWork.Save();
                return new JsonResult($"Delete Country By Name Success");

            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message);
            }
        }

    }
}
