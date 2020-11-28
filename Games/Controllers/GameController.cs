using Games.Services;
using Games.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;

        public GameController(IGameService gameService,ICategoryService categoryService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            return Ok(await _gameService.GetAll());
        }

        [HttpPost("Add")]
        public async Task<ActionResult<GameDto>> Add([FromBody] GameDto game)
        {
            var addedGame = await _gameService.Add(game);
            return Created(addedGame.Id.ToString(),addedGame);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<GameDto>> Update([FromBody] GameDto game)
        {
            await _gameService.Update(game);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<GameDto>> Remove(int id)
        {
            await _gameService.Remove(id);
            return Ok();
        }
    }
}
