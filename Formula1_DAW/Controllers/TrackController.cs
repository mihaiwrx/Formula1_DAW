using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.TrackService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/track")]
    [ApiController]
    public class TrackController
    {
        public ITrackService _trackService { get; set; }
        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            Track track = await _trackService.Get(id);
            TrackDto trackDto = new TrackDto()
            {
                Id = track.Id,
                Name = track.Name,
                Length = track.Length,
                Capacity = track.Capacity,
                IdCountry = track.IdCountry
                //NameCountry = track.Country.Name
            };
            return new OkObjectResult(trackDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Track> tracks = await _trackService.GetAll();
            List<TrackDto> trackDtos = new List<TrackDto>();
            foreach (var track in tracks)
            {
                TrackDto item = new TrackDto()
                {
                    Id = track.Id,
                    Name = track.Name,
                    Length = track.Length,
                    Capacity = track.Capacity,
                    IdCountry = track.IdCountry
                    //NameCountry = track.Country.Name
                };
                trackDtos.Add(item);
            }
            return new OkObjectResult(trackDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackDto model)
        {
            Track track = new Track()
            {
                Name = model.Name,
                Length = model.Length,
                Capacity = model.Capacity,
                IdCountry = model.IdCountry
            };
            await _trackService.Create(track);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TrackDto model, int id)
        {
            Track track = await _trackService.Get(id);
            if (model.Name != track.Name)
            {
                track.Name = model.Name;
            }
            if (model.Length != track.Length)
            {
                track.Length = model.Length;
            }
            if (model.Capacity != track.Capacity)
            {
                track.Capacity = model.Capacity;
            }
            if (model.IdCountry != track.IdCountry)
            {
                track.IdCountry = model.IdCountry;
            }
            await _trackService.Update(track);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Track track = await _trackService.Get(id);
            await _trackService.Delete(track);
            return new OkObjectResult("Model deleted.");
        }
    }
}
