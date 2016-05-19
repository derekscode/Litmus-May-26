using System;
using System.Collections.Generic;
using System.Linq;
using Litmus.Entities;

namespace Litmus.Services
{
    public interface ICardData
    {
        IEnumerable<Card> GetAll();
        Card Get(int id);
        void Add(Card newCard);
        void Update(Card newCard);
        void Delete(int id);
    }

    public class SqlCardData : ICardData
    {
        private LitmusDbContext _context;

        public SqlCardData(LitmusDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Card> GetAll()
        {

            var activeCards = _context.Cards.ToList().Where(x => x.Active);

            return activeCards;
        }

        public Card Get(int id)
        {
            Card card = _context.Cards.FirstOrDefault(c => c.Id == id);
            
            return card;
        }

        public void Add(Card newCard)
        {
            newCard.LastChanged = DateTime.Now;

            _context.Add(newCard);
            _context.SaveChanges();
        }

        public void Update(Card newCard)
        {
            var oldCard = Get(newCard.Id);

            if (oldCard != null)
            {
                oldCard.IdNumber = newCard.IdNumber;
                oldCard.State = newCard.State;
                oldCard.Version = newCard.Version;
                oldCard.Orientation = newCard.Orientation;
                oldCard.Expiration = newCard.Expiration;
                oldCard.BirthYear= newCard.BirthYear;
                oldCard.Notes= newCard.Notes;
                oldCard.IsDamaged= newCard.IsDamaged;
                oldCard.IsPaper= newCard.IsPaper;
                oldCard.HasMagstripe = newCard.HasMagstripe;
                oldCard.HasBarcode = newCard.HasBarcode;
                oldCard.Location= newCard.Location;
                oldCard.LastChanged = DateTime.Now;
                oldCard.Active = newCard.Active;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var cardToDelete = Get(id);

            _context.Remove(cardToDelete);
            _context.SaveChanges();
        }
    }

    public class InMemoryCardData : ICardData
    {
        static List<Card> _cards;

        static InMemoryCardData()
        {
            _cards = new List<Card>()
            {
                new Card()
                {
                    Id = 1,
                    IdNumber = "C3820335",
                    State = "CA",
                    Version = "2016R2",
                    Orientation = "L",
                    Expiration = "2/12/2017",
                    BirthYear = 1974,
                    Notes = "Dirty back",
                    IsDamaged = true,
                    IsPaper = true,
                    HasMagstripe = false,
                    HasBarcode = false,
                    Location = "IDV"
                },
                new Card()
                {
                    Id = 2,
                    IdNumber = "K349223",
                    State = "KS",
                    Version = "2015R1",
                    Orientation = "P",
                    Expiration = "1/2/2020",
                    BirthYear = 2000,
                    Notes = "Under age",
                    IsDamaged = false,
                    IsPaper = true,
                    HasMagstripe = true,
                    HasBarcode = false,
                    Location = "SD"
                },
                new Card()
                {
                    Id = 3,
                    IdNumber = "I34832092",
                    State = "IL",
                    Version = "2011R2",
                    Orientation = "L",
                    Expiration = "2/12/2017",
                    BirthYear = 1990,
                    Notes = "Customer contacted",
                    IsDamaged = true,
                    IsPaper = false,
                    HasMagstripe = false,
                    HasBarcode = true,
                    Location = "MR"
                },

            };
        }

        public IEnumerable<Card> GetAll()
        {
            return _cards;
        }

        public Card Get(int id)
        {
            return _cards.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Card newCard)
        {
            newCard.Id = _cards.Max(r => r.Id) + 1;
            _cards.Add(newCard);
        }

        public void Update(Card card)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
