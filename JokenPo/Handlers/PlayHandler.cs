using JokenPo.Commands;
using JokenPo.Data.Interfaces;
using JokenPo.Models;
using JokenPo.Models.CommandResponses;
using JokenPo.Models.AbstractClasses;
using MediatR;

namespace JokenPo.Handlers
{
    public class PlayHandler : IRequestHandler<PlayCommand, PlayCommandResponse>
    {
        private IPlayerRepository _playerRepository;

        public PlayHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayCommandResponse> Handle(PlayCommand command, CancellationToken cancellationToken) 
        {
            var moveMadeSuccessfully = _playerRepository.PlayerMakesMove(command.Id, command.Hand);
            bool gameHasEnded = GameHasEnded();
            Player winner = null;

            if (moveMadeSuccessfully && gameHasEnded)
            {
                winner = FindWinner();
            }

            var response = new PlayCommandResponse()
            {
                MoveMadeSuccessfully = moveMadeSuccessfully,
                GameEnded = gameHasEnded,
                Winner = winner
            };

            return response;
        }

        private bool GameHasEnded()
        {
            var players = _playerRepository.GetPlayers();
            var gameHasEnded = true;

            foreach(var player in players) 
            {
                if(player.Hand is null) 
                {
                    gameHasEnded = false;
                    break;
                } 
            }

            return gameHasEnded;
        }

        private Player? FindWinner() 
        {
            var players = _playerRepository.GetPlayers();

            foreach (var player in players) 
            {
                List<Hand> playerHandWeaknesses = player.Hand.GetWeaknesses();
                bool playerIsTheWinner = true;

                foreach (var otherPlayer in players)
                {
                    if (playerHandWeaknesses.Contains(otherPlayer.Hand))
                    {
                        playerIsTheWinner = false;
                        break;
                    }
                }

                if (playerIsTheWinner)
                {
                    return player;
                }
            }

            return null;
        }
    }
}
