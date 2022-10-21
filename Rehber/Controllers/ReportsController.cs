using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rehber.DataAccess.Interfaces;

namespace Rehber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ILocationDAL _locationDAL;

        public ReportsController(ILocationDAL locationDAL)
        {
            _locationDAL = locationDAL;
        }

        // En çok -> En az olacak şekilde konumlarının sayılarıyla listelenmes

        [HttpGet("getLocationReport")]
        public IActionResult GetLocationReport()
        {
            var allLocation = _locationDAL.GetDefaults(a => a.ID != 0);
            var result =
                     from e in allLocation
                     group e by e.Value into g
                        select new { Location = g.Key, Total = g.Count() };

            return Ok(result);

        }
    }
}
