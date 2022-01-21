using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int Number { get; set; }
        public int BirthYear { get; set; }
        public int IdTeam { get; set; }

        public virtual Team Team { get; set; }
    }
}
