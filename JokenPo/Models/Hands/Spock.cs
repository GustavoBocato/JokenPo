using JokenPo.Models.AbstractClasses;

namespace JokenPo.Models.Hands
{
    public class Spock : Hand
    {
        private List<Hand> weaknesses = new List<Hand>()
        {
            new Paper(),
            new Lizard()
        };

        public override List<Hand> GetWeaknesses()
        {
            return weaknesses;
        }
    }
}
