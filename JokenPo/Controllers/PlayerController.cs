using JokenPo.Commands;
using JokenPo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JokenPo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "PostPlayer")]
        public async Task<IActionResult> Post([FromBody] CreatePlayerCommand command)
        {
            var player = await _mediator.Send(command);
            return Ok(player);
        }

        [HttpDelete("player", Name = "DeletePlayer")]
        public async Task<IActionResult> Delete([FromBody] DeletePlayerCommand command)
        {
            var result = _mediator.Send(command);

            if (result.Result)
            {
                return Ok("Player deleted with success.");
            }

            return NotFound("Player to be deleted was not found in our database.");
        }

        [HttpPatch(Name = "Play")]
        public async Task<IActionResult> Patch([FromBody] PlayCommand command)
        {
            var result = _mediator.Send(command).Result;

            if (result) 
            {
                return Ok("Player made the move successfully");
            }

            return NotFound("Player to make a move was not found in our database.");
        }

        [HttpGet(Name = "GetStatus")]
        public async Task<IActionResult> GetStatus()
        {
            var result = await _mediator.Send(new GetStatusQuery());
            return Ok(result);
        }

        [HttpDelete("restart", Name = "RestartGame")]
        public async Task<IActionResult> RestartGame()
        {
            var result = await _mediator.Send(new RestartGameCommand());
            return Ok("The game was restarted successfully.");
        }
    }
}
