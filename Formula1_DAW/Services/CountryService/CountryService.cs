using Formula1_DAW.Context;
using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.CountryService
{
    public class CountryService : ICountryService
    {
        public ContextDAW _dbContext { get; set; }

        public CountryService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }
        
        public async Task<Country> Get(int Id)
        {
            return await _dbContext.Countries.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Country>> GetAll()
        {
            return await _dbContext.Countries.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<SelectItemDto>> GetAllAsSelect()
        {
            return await _dbContext.Countries.Select(x => new SelectItemDto { Value = x.Id, Label = x.Name }).ToListAsync();
        }

        public async Task Create(Country country)
        {
            _dbContext.Add(country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Country country)
        {
            _dbContext.Update(country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Country country)
        {
            _dbContext.Remove(country);
            await _dbContext.SaveChangesAsync();
        }
    }
}
