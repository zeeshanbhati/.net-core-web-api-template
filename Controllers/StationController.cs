using Microsoft.AspNetCore.Mvc;
using EFTemplate.Request;
using EFTemplate.Services;
using EFTemplate.Models;

namespace EFTemplate.Controllers
{
    [ApiController]
    [Route("station-api")]
    public class StationController : Controller
    {
        private readonly StationService stationService;

        public StationController(StationService stationService)
        {
            this.stationService = stationService;
        }

        [HttpPost("CreateStation")]
        public async Task<ActionResult<Guid>> CreateStation(CreateStationRequest createStationRequest)
        {
            Guid createdId = await stationService.CreateStation(createStationRequest);
            return createdId;
        }

        [HttpGet("ListStations")]
        public async Task<ActionResult<List<Station>>> ListStations(int limit = 10, int offset = 0)
        {
            List<Station> stations = await stationService.ListStations(limit, offset);
            return stations;
        }


    }
}
