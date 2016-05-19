using System.Collections.Generic;
using System.Linq;
using Litmus.Entities;
using Litmus.Services;
using Microsoft.AspNet.Mvc;


namespace Litmus.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private ILocationData _locationData;

        public LocationController(ILocationData locationData)
        {
            _locationData = locationData;
        }

        // GET: api/location
        [HttpGet]
        public Location[] Get()
        {
            var locations = _locationData.Get().ToArray();

            return locations;
        }

      
    }
}
