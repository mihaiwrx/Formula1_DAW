using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.DriverService
{
    public interface IDriverService
    {
        Task<Driver> Get(int Id);
        Task<List<Driver>> GetAll();
        Task Create(Driver driver);
        Task Update(Driver driver);
        Task Delete(Driver driver);
    }
}
