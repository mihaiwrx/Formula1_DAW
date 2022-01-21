using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.DTOs
{
    public class TeamDto
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int IdTeamPrincipal { get; set; }

        public string NameTeamPrincipal { get; set; }
    }
}
