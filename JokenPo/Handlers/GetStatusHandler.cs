using JokenPo.Data.Interfaces;
using JokenPo.Utils;
using JokenPo.Models.RequestResponses;
using JokenPo.Queries;
using MediatR;
using JokenPo.Models;

namespace JokenPo.Handlers
{
    public class GetStatusHandler : IRequestHandler<GetStatusQuery, GetStatusQueryResponse>
    {
        private IPlayerRepository _playerRepository;

        public GetStatusHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<GetStatusQueryResponse> Handle(GetStatusQuery getStatusQuery, CancellationToken c)
        {
            var players = _playerRepository.GetPlayers();

            var response = new GetStatusQueryResponse()
            {
                Players = new List<Player>(players),
                ResultMessage = GameResultDeterminator.GameStatusMessage(players)
            };

            if (GameResultDeterminator.GameHasEnded(players))
            {
                _playerRepository.Clean();
            }

            return response;
        }
    }
}
