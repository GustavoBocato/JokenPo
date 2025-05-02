using JokenPo.Data.Interfaces;
using JokenPo.Commands;
using MediatR;

namespace JokenPo.Handlers
{
    public class RestartGameCommandHandler : IRequestHandler<RestartGameCommand, Unit>
    {
        private IPlayerRepository _playerRepository;

        public RestartGameCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Unit> Handle(RestartGameCommand command, CancellationToken c) 
        {
            _playerRepository.Clean();
            return Unit.Value;
        }
    }
}
