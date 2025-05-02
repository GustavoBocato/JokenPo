using JokenPo.Commands;
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

        [HttpDelete(Name = "DeletePlayer")]
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
            var moveMadeSuccessfully = result.MoveMadeSuccessfully;
            var gameEnded = result.GameEnded;
            var winner = result.Winner;

            if (moveMadeSuccessfully)
            {
                if (gameEnded)
                {
                    if(winner is not null)
                    {
                        return Ok("The player made the move successfully. And the game has ended," +
                            $" the winner is {winner}");
                    }
                    else
                    {
                        return Ok("The player made the move successfully. And the game has ended" +
                            " in a draw.");
                    }
                }

                return Ok("Player made the move successfully");
            }

            return NotFound("Player to make a move was not found in our database.");
        }
    }
}
