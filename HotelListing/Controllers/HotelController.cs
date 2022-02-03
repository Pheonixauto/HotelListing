using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork iunitOfWork;
        private readonly ILogger<HotelController> ilogger;
        private readonly IMapper imapper;

        public HotelController(IUnitOfWork unitofWork, ILogger<HotelController> logger, IMapper mapper)
        {
            iunitOfWork = unitofWork;
            ilogger = logger;
            imapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotel()
        {
            try
            {
                var hotels = await iunitOfWork.Hotels.GetAll();
                var result = imapper.Map<List<HotelDTO>>(hotels);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ilogger.LogError(ex,$"wrong");
                return StatusCode(500, "try again");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var hotel = await iunitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                //var result = imapper.Map<HotelDTO>(hotel);
                return new JsonResult(hotel);
            }
            catch (Exception ex)
            {

                ilogger.LogError(ex, $"wrong");
                return StatusCode(500, "try again");
            }
        }
    }
}
