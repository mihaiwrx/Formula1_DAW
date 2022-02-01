using Formula1_DAW.Context;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.SponsorService
{
    public class SponsorService : ISponsorService
    {
        public ContextDAW _dbContext { get; set; }

        public SponsorService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Sponsor> Get(int Id)
        {
            return await _dbContext.Sponsors.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Sponsor>> GetAll()
        {
            return await _dbContext.Sponsors.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task Create(Sponsor sponsor)
        {
            _dbContext.Add(sponsor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Sponsor sponsor)
        {
            _dbContext.Update(sponsor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Sponsor sponsor)
        {
            _dbContext.Remove(sponsor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
