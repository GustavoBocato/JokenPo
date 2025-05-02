using JokenPo.Data.Interfaces;
using JokenPo.Models;
using JokenPo.Models.Enums;

namespace JokenPo.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<Player> players = new List<Player>();

        public List<Player> GetPlayers()
        {
            return players;
        }

        public Player Add(Player player) 
        {
            players.Add(player);
            return players.Where(p => p.Id == player.Id).First();
        }

        public bool Remove(Guid id) 
        {
            return players.RemoveAll(p => p.Id == id) > 0;
        }

        public bool PlayerMakesMove(Guid id, Hand hand)
        {
            var player = players.Where(p =>p.Id == id).First();
            
            if(player == null) return false;

            player.Hand = hand;
            return true;
        }

        public void Clean()
        {
            players.Clear();
        }
    }
}
