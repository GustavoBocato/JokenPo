using JokenPo.Models.AbstractClasses;

namespace JokenPo.Models.Hands
{
    public class Rock : Hand
    {
        private List<Hand> weaknesses = new List<Hand>()
        {
            new Paper(),
            new Spock()
        };

        public override List<Hand> GetWeaknesses()
        {
            return weaknesses;
        }
    }
}
