using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.TeamService
{
    public interface ITeamService
    {
        Task<Team> Get(int Id);
        Task<List<Team>> GetAll();
        Task Create(Team team);
        Task Update(Team team);
        Task Delete(Team team);
    }
}
