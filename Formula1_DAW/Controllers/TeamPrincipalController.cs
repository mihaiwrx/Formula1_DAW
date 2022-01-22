using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.TeamPrincipalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/teamprincipal")]
    [ApiController]
    public class TeamPrincipalController
    {
        public ITeamPrincipalService _teamPrincipalService { get; set; }
        public TeamPrincipalController(ITeamPrincipalService teamPrincipalService)
        {
            _teamPrincipalService = teamPrincipalService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            TeamPrincipal teamPrincipal = await _teamPrincipalService.Get(id);
            TeamPrincipalDto teamPrincipalDto = new TeamPrincipalDto()
            {
                Id = teamPrincipal.Id,
                FirstName = teamPrincipal.FirstName,
                LastName = teamPrincipal.LastName
            };
            return new OkObjectResult(teamPrincipalDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<TeamPrincipal> teamPrincipals = await _teamPrincipalService.GetAll();
            List<TeamPrincipalDto> teamPrincipalDtos = new List<TeamPrincipalDto>();
            foreach (var teamprincipal in teamPrincipals)
            {
                TeamPrincipalDto item = new TeamPrincipalDto()
                {
                    Id = teamprincipal.Id,
                    FirstName = teamprincipal.FirstName,
                    LastName = teamprincipal.LastName
                };
                teamPrincipalDtos.Add(item);
            }
            return new OkObjectResult(teamPrincipalDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamPrincipalDto model)
        {
            TeamPrincipal teamPrincipal = new TeamPrincipal()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            await _teamPrincipalService.Create(teamPrincipal);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TeamPrincipalDto model, int id)
        {
            TeamPrincipal teamPrincipal = await _teamPrincipalService.Get(id);
            if (model.FirstName != teamPrincipal.FirstName)
            {
                teamPrincipal.FirstName= model.FirstName;
            }
            if (model.LastName != teamPrincipal.LastName)
            {
                teamPrincipal.LastName = model.LastName;
            }
            await _teamPrincipalService.Update(teamPrincipal);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            TeamPrincipal teamPrincipal = await _teamPrincipalService.Get(id);
            await _teamPrincipalService.Delete(teamPrincipal);
            return new OkObjectResult("Model deleted.");
        }
    }
}
