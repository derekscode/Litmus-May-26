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
                    CardId = "one",
                    State = "CA",
                    Version = "http://localhost:8462/api/card",
                    Orientation = "L",
                    Expiration = "2/12/2017",
                    BirthYear = 1974,
                    Notes = "Dirty back",
                    IsDamaged = true,
                    IsPaper = true,
                    HasMagStripe = false,
                    HasBarcode = false,
                    Location = "IDV"
                },
                new Card()
                {
                    Id = 2,
                    CardId = "two",
                    State = "KS",
                    Version = "2015R1",
                    Orientation = "P",
                    Expiration = "1/2/2020",
                    BirthYear = 2000,
                    Notes = "Under age",
                    IsDamaged = false,
                    IsPaper = true,
                    HasMagStripe = true,
                    HasBarcode = false,
                    Location = "SD"
                },
                new Card()
                {
                    Id = 3,
                    CardId = "three",
                    State = "IL",
                    Version = "2011R2",
                    Orientation = "L",
                    Expiration = "2/12/2017",
                    BirthYear = 1990,
                    Notes = "Customer contacted",
                    IsDamaged = true,
                    IsPaper = false,
                    HasMagStripe = false,
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
    }
}
