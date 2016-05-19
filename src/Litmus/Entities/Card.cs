using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Litmus.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string State { get; set; }

        public string Version { get; set; }
        public string Orientation { get; set; }
        public string Expiration { get; set; }
        public int BirthYear { get; set; }
        public string Notes { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsPaper { get; set; }
        public bool HasMagstripe { get; set; }
        public bool HasBarcode { get; set; }
        public string Location { get; set; }

        public bool Active { get; set; }

        public DateTime LastChanged { get; set; }
        public string DisplayLastChanged
        {
            get { return LastChanged.ToString("G"); }
            set { }
        }

        public Card ShallowCopy()
        {
            return (Card)this.MemberwiseClone();
        }
    }
}
