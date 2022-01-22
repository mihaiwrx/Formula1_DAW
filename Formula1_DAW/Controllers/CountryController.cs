using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.CountryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController
    {
        public ICountryService _countryService { get; set; }
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            Country country = await _countryService.Get(id);
            CountryDto countryDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name,
                Continent = country.Continent
            };
            return new OkObjectResult(countryDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Country> countries = await _countryService.GetAll();
            List<CountryDto> countryDtos = new List<CountryDto>();
            foreach(var country in countries)
            {
                CountryDto item = new CountryDto()
                {
                    Id = country.Id,
                    Name = country.Name,
                    Continent = country.Continent
                };
                countryDtos.Add(item);
            }
            return new OkObjectResult(countryDtos);
        }

        [HttpGet("getallselect")]
        public async Task<IActionResult> GetAllAsSelect()
        {
            List<SelectItemDto> selectItemDtos = await _countryService.GetAllAsSelect();
            return new OkObjectResult(selectItemDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryDto model)
        {
            Country country = new Country()
            {
                Name = model.Name,
                Continent = model.Continent
            };
            await _countryService.Create(country);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CountryDto model, int id)
        {
            Country country = await _countryService.Get(id);
            if(model.Name != country.Name)
            {
                country.Name = model.Name;
            }
            if(model.Continent != country.Continent)
            {
                country.Continent = model.Continent;
            }
            await _countryService.Update(country);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Country country = await _countryService.Get(id);
            await _countryService.Delete(country);
            return new OkObjectResult("Model deleted.");
        }
    }
}
