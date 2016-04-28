using Litmus.Entities;
using Microsoft.AspNet.Mvc;
using Litmus.Services;
using Litmus.ViewModels;

namespace Litmus.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public RestaurantController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentGreeting = _greeter.GetGreeting()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant()
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };

                _restaurantData.Add(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();

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
