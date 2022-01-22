using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.TeamService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController
    {
        public ITeamService _teamService { get; set; }
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            Team team = await _teamService.Get(id);
            TeamDto teamDto = new TeamDto()
            {
                Id = team.Id,
                Name = team.Name,
                Location = team.Location,
                IdTeamPrincipal = team.IdTeamPrincipal
                //NameTeamPrincipal = team.TeamPrincipal.FirstName + team.TeamPrincipal.LastName
            };
            return new OkObjectResult(teamDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Team> teams = await _teamService.GetAll();
            List<TeamDto> teamDtos= new List<TeamDto>();
            foreach (var team in teams)
            {
                TeamDto item = new TeamDto()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Location = team.Location,
                    IdTeamPrincipal = team.IdTeamPrincipal
                    //NameTeamPrincipal = team.TeamPrincipal.FirstName + team.TeamPrincipal.LastName
                };
                teamDtos.Add(item);
            }
            return new OkObjectResult(teamDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamDto model)
        {
            Team team = new Team()
            {
                Name = model.Name,
                Location = model.Location,
                IdTeamPrincipal = model.IdTeamPrincipal
            };
            await _teamService.Create(team);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TeamDto model, int id)
        {
            Team team = await _teamService.Get(id);
            if (model.Name != team.Name)
            {
                team.Name = model.Name;
            }
            if (model.Location != team.Location)
            {
                team.Location = model.Location;
            }
            if (model.IdTeamPrincipal != team.IdTeamPrincipal)
            {
                team.IdTeamPrincipal = model.IdTeamPrincipal;
            }
            await _teamService.Update(team);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Team team = await _teamService.Get(id);
            await _teamService.Delete(team);
            return new OkObjectResult("Model deleted.");
        }
    }
}
