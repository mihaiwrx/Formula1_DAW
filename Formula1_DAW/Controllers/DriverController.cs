using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.DriverService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class DriverController
    {
        public IDriverService _driverService { get; set; }
        public DriverController (IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            Driver driver = await _driverService.Get(id);
            DriverDto driverDto= new DriverDto()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Nationality = driver.Nationality,
                Number = driver.Number,
                BirthYear = driver.BirthYear
                //NameTeam = driver.Team.Name
            };
            return new OkObjectResult(driverDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Driver> drivers= await _driverService.GetAll();
            List<DriverDto> driverDtos= new List<DriverDto>();
            foreach (var driver in drivers)
            {
                DriverDto item = new DriverDto()
                {
                    Id = driver.Id,
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    Nationality = driver.Nationality,
                    Number = driver.Number,
                    BirthYear = driver.BirthYear,
                    IdTeam = driver.IdTeam
                    //NameTeam = driver.Team.Name
                };
                driverDtos.Add(item);
            }
            return new OkObjectResult(driverDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DriverDto model)
        {
            Driver driver = new Driver()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Nationality = model.Nationality,
                Number = model.Number,
                BirthYear = model.BirthYear,
                IdTeam = model.IdTeam
            };
            await _driverService.Create(driver);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DriverDto model, int id)
        {
            Driver driver = await _driverService.Get(id);
            if (model.FirstName != driver.FirstName)
            {
                driver.FirstName = model.FirstName;
            }
            if (model.LastName != driver.LastName)
            {
                driver.LastName = model.LastName;
            }
            if (model.Nationality != driver.Nationality)
            {
                driver.Nationality = model.Nationality;
            }
            if (model.Number != driver.Number)
            {
                driver.Number = model.Number;
            }
            if (model.BirthYear != driver.BirthYear)
            {
                driver.BirthYear = model.BirthYear;
            }
            if (model.IdTeam != driver.IdTeam)
            {
                driver.IdTeam = model.IdTeam;
            }
            await _driverService.Update(driver);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Driver driver = await _driverService.Get(id);
            await _driverService.Delete(driver);
            return new OkObjectResult("Model deleted.");
        }
    }
}
