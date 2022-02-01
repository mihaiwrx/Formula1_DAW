using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Models
{
    public class SponsorTeam
    {
        public int IdSponsor { get; set; }
        public int IdTeam { get; set; }

        public virtual Sponsor Sponsor { get; set; }
        public virtual Team Team { get; set; }
    }
}
