using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.DTOs
{
    public class SponsorTeamDto
    {
        public int IdSponsor { get; set; }
        public int IdTeam { get; set; }

        public string NameSponsor { get; set; }
        public string NameTeam { get; set; }
    }
}
