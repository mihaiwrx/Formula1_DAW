using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.SponsorService
{
    public interface ISponsorService
    {
        Task<Sponsor> Get(int Id);
        Task<List<Sponsor>> GetAll();
        Task Create(Sponsor sponsor);
        Task Update(Sponsor sponsor);
        Task Delete(Sponsor sponsor);
    }
}

