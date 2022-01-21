using Formula1_DAW.Context;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.TeamService
{
    public class TeamService: ITeamService
    {
        public ContextDAW _dbContext { get; set; }

        public TeamService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Team> Get(int Id)
        {
            return await _dbContext.Teams.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Team>> GetAll()
        {
            return await _dbContext.Teams.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task Create(Team team)
        {
            _dbContext.Add(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Team team)
        {
            _dbContext.Update(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Team team)
        {
            _dbContext.Remove(team);
            await _dbContext.SaveChangesAsync();
        }
    }
}
