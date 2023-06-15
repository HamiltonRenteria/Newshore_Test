using Microsoft.AspNetCore.Mvc;
using Newshore.Core.Entities;
using Newshore.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newshore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourney _journey;

        public JourneyController(IJourney journey)
        {
            _journey = journey;
        }

        // GET: api/<JourneyController>
        [HttpGet]
        public async Task<IActionResult> GetJourney([FromQuery] Request request)
        {
            IEnumerable<ResponseJourney> responseJourney = await _journey.GetJourneys(request.Origin!, request.Destination!);
            return Ok(responseJourney);
        }
    }
}
