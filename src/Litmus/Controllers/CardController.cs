using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Litmus.Entities;
using Litmus.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Litmus.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private ICardData _cardData;
        private ILogData _logData;

        public CardController(ICardData cardData, ILogData logData)
        {
            _cardData = cardData;
            _logData = logData;
        }

        // GET: api/card
        [HttpGet]
        public Card[] Get()
        {
            var cards = _cardData.GetAll();
            return cards.ToArray();
        }

        // GET api/card/1
        [HttpGet("{id}")]
        public Card Get(int id)
        {
            var card = _cardData.Get(id);
            return card;
        }

        // POST api/card
        [HttpPost]
        public IActionResult Create([FromBody] Card card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cardData.Add(card);
                    CreateNewLog(card, null);

                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(new { Data = card });
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            return Json("Failed");
        }

        // PUT api/card/1
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Card updatedCard)
        {
            if (updatedCard == null || updatedCard.Id != id)
            {
                return HttpBadRequest();
            }

            Card oldCard = _cardData.Get(id);
            
            _cardData.Update(updatedCard);

            var old = oldCard.State;
            var oldplus1 = updatedCard.State;
            
            CreateNewLog(updatedCard, oldCard);

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json("Complete!");
        }

        // DELETE api/card/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cardData.Delete(id);
        }

        public void CreateNewLog(Card newCard, Card oldCard)
        {
            Log newLog = new Log()
            {
                DateChanged = DateTime.Now,

                CardId = newCard.CardId,
                //OldCard = JsonConvert.SerializeObject(oldCard),
                //NewCard = JsonConvert.SerializeObject(newCard),
                OldCard = oldCard.State,
                NewCard = newCard.State,
                User = "John Smith"
            };

            _logData.Add(newLog);
        }
    }
}
