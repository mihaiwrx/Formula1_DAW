using Formula1_DAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Services.UserService
{
    public interface IUserService
    {
        Task<User> Get(int Id);
        Task<List<User>> GetAll();
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
