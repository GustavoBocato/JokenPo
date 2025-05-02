using JokenPo.Commands;
using JokenPo.Data.Interfaces;
using JokenPo.Models;
using JokenPo.Models.RequestResponses;
using JokenPo.Models.Enums;
using MediatR;

namespace JokenPo.Handlers
{
    public class PlayHandler : IRequestHandler<PlayCommand, bool>
    {
        private IPlayerRepository _playerRepository;

        public PlayHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> Handle(PlayCommand command, CancellationToken cancellationToken)
        {
            return _playerRepository.PlayerMakesMove(command.Id, command.Hand);
        }
    }
}
