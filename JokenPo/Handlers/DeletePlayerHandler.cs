using JokenPo.Commands;
using JokenPo.Data.Interfaces;
using MediatR;

namespace JokenPo.Handlers
{
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private IPlayerRepository _playerRepository;

        public DeletePlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> Handle(DeletePlayerCommand command, CancellationToken cancellationToken)
        {
            return _playerRepository.Remove(command.Id);
        }
    }
}
