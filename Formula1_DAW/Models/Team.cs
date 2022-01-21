using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int IdTeamPrincipal { get; set; }

        public virtual TeamPrincipal TeamPrincipal { get; set; }
    }
}
