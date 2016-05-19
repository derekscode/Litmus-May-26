using System;
using System.Collections.Generic;
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
            var logs = _logData.GetAll().ToList();

            var result = logs
                .OrderByDescending(x => x.DateChanged)
                .ThenByDescending(x => x.CardId);


            return result.ToArray();
        }

        // GET api/log/1
        [HttpGet("{id}")]
        public Log Get(int id)
        {
            var log = _logData.Get(id);
            return log;
        }

        // POST is done in CardController
        // PUT and DELETE not needed

    }
}
