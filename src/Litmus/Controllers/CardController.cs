﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Litmus.Entities;
using Litmus.Services;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Litmus.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {

        private ICardData _cardData;

        public CardController(ICardData cardData)
        {
            _cardData = cardData;
        }
        
        // GET: api/card
        [HttpGet]
        public Card[] Get()
        {
            var cards = _cardData.GetAll();
            return cards.ToArray();
        }

        // GET api/card/5
        [HttpGet("{id}")]
        public Card Get(int id)
        {
            var card = _cardData.Get(id);
            return card;
        }

        // POST api/card
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/card/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/card/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
