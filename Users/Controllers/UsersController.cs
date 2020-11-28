
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Services;
using Users.Services.Dto;

namespace Users.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpPost()]
        public async Task<ActionResult<UserDto>> Add([FromBody] UserDto dto)
        {
            var entity = await _userService.Add(dto);
            return Created(entity.Id.ToString(), entity);
        }

        [HttpPut()]
        public async Task<ActionResult<UserDto>> UpdateGame([FromBody] UserDto dto)
        {
            await _userService.Update(dto);
            return Ok();
        }

        [HttpDelete()]
        public async Task<ActionResult<UserDto>> RemoveGame(int id)
        {
            await _userService.Remove(id);
            return Ok();
        }
    }
}
