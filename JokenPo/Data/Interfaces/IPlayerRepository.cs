using JokenPo.Models;
using JokenPo.Models.AbstractClasses;

namespace JokenPo.Data.Interfaces
{
    public interface IPlayerRepository 
    {
        public List<Player> GetPlayers();
        public Player Add(Player player);
        public bool Remove(Guid id);
        public bool PlayerMakesMove(Guid id, Hand play);
    }
}
