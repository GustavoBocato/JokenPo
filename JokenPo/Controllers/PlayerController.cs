using Microsoft.AspNetCore.Mvc;
using MediatR;
using JokenPo.Models;

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
        public async Task<IActionResult> Post(Player player)
        {
            var player = await _mediator.Send(new GetUserByIdQuery(id));

            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpDelete(Name = "DeletePlayer")]
        public async Task<IActionResult> Delete(Guid id)
        {

        }
    }
}
