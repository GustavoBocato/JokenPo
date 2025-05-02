using JokenPo.Models.Enums;
using JokenPo.Models;

namespace JokenPo.Utils
{
    public class GameResultDeterminator
    {
        public static List<Hand> RockWeakenesses = new List<Hand>()
        {
            Hand.Paper,
            Hand.Spock
        };

        public static List<Hand> PaperWeakenesses = new List<Hand>()
        {
            Hand.Scissors,
            Hand.Lizard
        };

        public static List<Hand> ScissorsWeakenesses = new List<Hand>()
        {
            Hand.Rock,
            Hand.Spock
        };

        public static List<Hand> SpockWeakenesses = new List<Hand>()
        {
            Hand.Paper,
            Hand.Lizard
        };

        public static List<Hand> LizardWeakenesses = new List<Hand>()
        {
            Hand.Scissors,
            Hand.Rock
        };

        public static bool GameHasEnded(List<Player> players)
        {
            if(!players.Any()) return false;

            var gameHasEnded = true;

            foreach (var player in players)
            {
                if (player.Hand == Hand.None)
                {
                    gameHasEnded = false;
                    break;
                }
            }

            return gameHasEnded;
        }

        public static Player FindWinner(List<Player> players)
        {
            foreach (var player in players)
            {
                List<Hand> playerHandWeaknesses = GetPlayersHandWeaknesses(player.Hand);
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

        public static List<Hand> GetPlayersHandWeaknesses(Hand hand) 
        {
            switch (hand) 
            {
                case Hand.Rock:
                    return RockWeakenesses;
                case Hand.Paper:
                    return PaperWeakenesses;
                case Hand.Scissors:
                    return ScissorsWeakenesses;
                case Hand.Spock:
                    return SpockWeakenesses;
                case Hand.Lizard:
                    return LizardWeakenesses;
                case Hand.None:
                    return null;
            }

            return null;
        }

        public static string GameStatusMessage(List<Player> players)
        {
            if (GameHasEnded(players))
            {
                var player = FindWinner(players);

                if(player is not null)
                {
                    return $"The game has finished and the winner is {player.Name}.";
                }

                return "The game has finished in a draw.";
            }

            return "The game has not finished yet.";
        }
    }
}
