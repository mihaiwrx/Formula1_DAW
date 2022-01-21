using Formula1_DAW.Context;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.TrackService
{
    public class TrackService : ITrackService
    {
        public ContextDAW _dbContext { get; set; }

        public TrackService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Track> Get(int Id)
        {
            return await _dbContext.Tracks.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Track>> GetAll()
        {
            return await _dbContext.Tracks.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task Create(Track track)
        {
            _dbContext.Add(track);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Track track)
        {
            _dbContext.Update(track);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Track track)
        {
            _dbContext.Remove(track);
            await _dbContext.SaveChangesAsync();
        }
    }
}
