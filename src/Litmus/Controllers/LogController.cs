using System;
using System.Linq;
using System.Net;
using Litmus.Entities;
using Litmus.Services;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Litmus.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private ILogData _logData;

        public LogController(ILogData logData)
        {
            _logData = logData;
        }


        // GET api/log
        [HttpGet]
        public Log[] Get()
        {
            var logs = _logData.GetAll();
            return logs.ToArray();
        }

        // GET api/log/1
        [HttpGet("{id}")]
        public Log Get(int id)
        {
            var log = _logData.Get(id);
            return log;
        }

        // POST api/log
        [HttpPost]
        public IActionResult Create([FromBody] Log log)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logData.Add(log);

                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(new { Data = log });
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            return Json("Failed");
        }

        // no PUT or DELETE needed for Log
        
    }
}
