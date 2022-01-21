using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
        public int Capacity { get; set; }
        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }
    }
}
