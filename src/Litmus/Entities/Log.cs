using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Litmus.Entities
{
    public class Log
    {
        // Log
        public int Id { get; set; }
        public DateTime DateChanged { get; set; }

        // Card
        public string CardId { get; set; }
        public Card OldCard { get; set; }
        public Card NewCard { get; set; }

        
        public string User { get; set; }
    }
}
