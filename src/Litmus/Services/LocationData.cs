using System.Collections.Generic;
using System.Linq;
using Litmus.Entities;

namespace Litmus.Services
{
    public interface ILocationData
    {
        IEnumerable<Location> Get();
    }

    public class LocationData : ILocationData
    {
        private LitmusDbContext _context;

        public LocationData(LitmusDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> Get()
        {
            var locations = _context.Locations.ToList();

            return locations;
        }


    }
}
