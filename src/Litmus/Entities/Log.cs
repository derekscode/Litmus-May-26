﻿using System;
using Microsoft.AspNet.Http;

namespace Litmus.Entities
{
    public class Log
    {
        // Log
        public int Id { get; set; }

        // Card
        public int CardId { get; set; }
        public string CardIdNumber { get; set; }

        public DateTime DateChanged { get; set; }

        public string DisplayDateChanged
        {
            get { return DateChanged.ToString("G"); }
            set { }
        }

        public string OldCard { get; set; }
        public string NewCard { get; set; }
        public string User { get; set; }




    }
}
