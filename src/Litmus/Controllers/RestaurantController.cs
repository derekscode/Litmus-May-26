using Microsoft.AspNet.Mvc;
using Litmus.Models;
using Litmus.Services;

namespace Litmus.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantData _restaurantData
            
            ;

        public RestaurantController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public ViewResult Index()
        {

            var model = _restaurantData.GetAll();
            
            return View(model);
        }










        // this returns json, perfect for an api
        public IActionResult Data()
        {
            var model = new Restaurant()
            {
                Id = 1,
                Name = "Sabatino's"
            };

            return new ObjectResult(model);
        }
    }
}
