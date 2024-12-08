using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RouteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoute()
        {
            // Lista punktów GPS symulująca trasę
            var route = new List<(double Latitude, double Longitude)>
            {
                (49.656390, 19.159260),
                (49.659000, 19.160000),
                (49.660500, 19.161500),
                (49.662000, 19.162700),
                (49.663500, 19.164200)
            };

            // Zwrócenie trasy jako JSON
            return Ok(route);
        }
    }
}
