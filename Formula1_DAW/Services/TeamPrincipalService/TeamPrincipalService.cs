using Formula1_DAW.Context;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.TeamPrincipalService
{
    public class TeamPrincipalService: ITeamPrincipalService
    {
        public ContextDAW _dbContext { get; set; }

        public TeamPrincipalService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<TeamPrincipal> Get(int Id)
        {
            return await _dbContext.TeamPrincipals.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<TeamPrincipal>> GetAll()
        {
            return await _dbContext.TeamPrincipals.OrderBy(x => x.FirstName).ToListAsync();
        }

        public async Task Create(TeamPrincipal teamPrincipal)
        {
            _dbContext.Add(teamPrincipal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TeamPrincipal teamPrincipal)
        {
            _dbContext.Update(teamPrincipal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TeamPrincipal teamPrincipal)
        {
            _dbContext.Remove(teamPrincipal);
            await _dbContext.SaveChangesAsync();
        }
    }
}
