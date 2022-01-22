using Formula1_DAW.DTOs;
using Formula1_DAW.Models;
using Formula1_DAW.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController
    {
        public IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EndpointUser(int id)
        {
            User user = await _userService.Get(id);
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role
            };
            return new OkObjectResult(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> users= await _userService.GetAll();
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto item = new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Role = user.Role
                };
                userDtos.Add(item);
            }
            return new OkObjectResult(userDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Role = model.Role
            };
            await _userService.Create(user);
            return new OkObjectResult("Model created.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UserDto model, int id)
        {
            User user = await _userService.Get(id);
            if (model.Username != user.Username)
            {
                user.Username = model.Username;
            }
            if (model.Password != user.Password)
            {
                user.Password = model.Password;
            }
            await _userService.Update(user);
            return new OkObjectResult("Model updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userService.Get(id);
            await _userService.Delete(user);
            return new OkObjectResult("Model deleted.");
        }
    }
}
