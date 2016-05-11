using System;
using Microsoft.AspNet.Http;

namespace Litmus.Entities
{
    public class Log
    {
        // Log
        public int Id { get; set; }

        // Card
        public string CardId { get; set; }

        public DateTime DateChanged { get; set; }

        public string DisplayDateChanged
        {
            get
            {
                var change = DateChanged;
                return change.ToString("G");
            }
            set { }
        }

        public string OldCard { get; set; }
        public string NewCard { get; set; }
        public string User { get; set; }

      


    }
}
