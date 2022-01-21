using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.TeamPrincipalService
{
    public interface ITeamPrincipalService
    {
        Task<TeamPrincipal> Get(int Id);
        Task<List<TeamPrincipal>> GetAll();
        Task Create(TeamPrincipal teamPrincipal);
        Task Update(TeamPrincipal teamPrincipal);
        Task Delete(TeamPrincipal teamPrincipal);
    }
}
