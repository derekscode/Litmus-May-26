using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Litmus.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }
    }
}
