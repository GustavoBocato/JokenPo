using JokenPo.Commands;
using JokenPo.Data.Interfaces;
using JokenPo.Models;
using MediatR;

namespace JokenPo.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreatePlayerCommand, Player>
    {
        private IPlayerRepository _playerRepository;

        public CreateUserHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            return await Task.FromResult(_playerRepository.Add(player));
        }
    }
}
