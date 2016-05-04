using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Litmus.Services;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Litmus.Entities
{
    [Route("api/trips")]
    public class TripController : Controller
    {
        private IRestaurantData _repository;

        public TripController(IRestaurantData repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repository.GetAll();

            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody] TripViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(vm);

                    // save to the database


                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<TripViewModel>(newTrip));
                }

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {Message = ex.Message});
            }


            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
