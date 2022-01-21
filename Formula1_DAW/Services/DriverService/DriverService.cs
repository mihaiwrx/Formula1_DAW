using Formula1_DAW.Context;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.DriverService
{
    public class DriverService: IDriverService
    {
        public ContextDAW _dbContext { get; set; }

        public DriverService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Driver> Get(int Id)
        {
            return await _dbContext.Drivers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Driver>> GetAll()
        {
            return await _dbContext.Drivers.OrderBy(x => x.FirstName).ToListAsync();
        }

        public async Task Create(Driver driver)
        {
            _dbContext.Add(driver);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Driver driver)
        {
            _dbContext.Update(driver);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Driver driver)
        {
            _dbContext.Remove(driver);
            await _dbContext.SaveChangesAsync();
        }
    }
}
