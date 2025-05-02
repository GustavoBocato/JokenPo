using JokenPo.Models.AbstractClasses;

namespace JokenPo.Models.Hands
{
    public class Scissors : Hand
    {
        private List<Hand> weaknesses = new List<Hand>()
        {
            new Rock(),
            new Spock()
        };

        public override List<Hand> GetWeaknesses()
        {
            return weaknesses;
        }
    }
}
