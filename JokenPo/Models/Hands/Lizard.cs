using JokenPo.Models.AbstractClasses;

namespace JokenPo.Models.Hands
{
    public class Lizard : Hand
    {
        private List<Hand> weaknesses = new List<Hand>()
        {
            new Rock(),
            new Scissors()
        };

        public override List<Hand> GetWeaknesses()
        {
            return weaknesses; 
        }
    }
}
