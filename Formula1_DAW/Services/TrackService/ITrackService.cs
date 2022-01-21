using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.TrackService
{
    public interface ITrackService
    {
        Task<Track> Get(int Id);
        Task<List<Track>> GetAll();
        Task Create(Track track);
        Task Update(Track track);
        Task Delete(Track track);
    }
}
