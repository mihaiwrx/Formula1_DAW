using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.CountryService
{
    public interface ICountryService
    {
        Task<Country> Get(int Id);
        Task<List<Country>> GetAll();
        Task Create(Country country);
        Task Update(Country country);
        Task Delete(Country country);
        Task<List<SelectItemDto>> GetAllAsSelect();

    }
}
