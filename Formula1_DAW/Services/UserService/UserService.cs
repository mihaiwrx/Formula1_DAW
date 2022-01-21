using Formula1_DAW.Context;
using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.UserService
{
    public class UserService : IUserService
    {
        public ContextDAW _dbContext { get; set; }

        public UserService(ContextDAW dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<User> Get(int Id)
        {
            return await _dbContext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.OrderBy(x => x.Username).ToListAsync();
        }

        public async Task Create(User user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
