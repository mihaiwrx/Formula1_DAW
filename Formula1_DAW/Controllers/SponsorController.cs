using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.SponsorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/sponsor")]
    [ApiController]
    public class SponsorController
    {
        public ISponsorService _sponsorService { get; set; }
        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            Sponsor sponsor = await _sponsorService.Get(id);
            SponsorDto sponsorDto = new SponsorDto()
            {
                Id = sponsor.Id,
                Name = sponsor.Name
            };
            return new OkObjectResult(sponsorDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Sponsor> sponsors = await _sponsorService.GetAll();
            List<SponsorDto> sponsorDtos = new List<SponsorDto>();
            foreach (var sponsor in sponsors)
            {
                SponsorDto item = new SponsorDto()
                {
                    Id = sponsor.Id,
                    Name = sponsor.Name
                };
                sponsorDtos.Add(item);
            }
            return new OkObjectResult(sponsorDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SponsorDto model)
        {
            Sponsor sponsor= new Sponsor()
            {
                Name = model.Name
            };
            await _sponsorService.Create(sponsor);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(SponsorDto model, int id)
        {
            Sponsor sponsor= await _sponsorService.Get(id);
            if (model.Name != sponsor.Name)
            {
                sponsor.Name = model.Name;
            }
            await _sponsorService.Update(sponsor);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Sponsor sponsor= await _sponsorService.Get(id);
            await _sponsorService.Delete(sponsor);
            return new OkObjectResult("Model deleted.");
        }
    }
}