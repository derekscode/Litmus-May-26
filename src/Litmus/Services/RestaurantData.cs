using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Litmus.Models;

namespace Litmus.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = 1,
                    Name = "Tersiguel's"
                },
                new Restaurant()
                {
                    Id = 2,
                    Name = "LJ's and the Kat"
                },
                new Restaurant()
                {
                    Id = 3,
                    Name = "King's Contrivance"
                },
            };
        }
    }
}
