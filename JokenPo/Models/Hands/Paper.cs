using JokenPo.Models.AbstractClasses;

namespace JokenPo.Models.Hands
{
    public class Paper : Hand
    {
        private List<Hand> weaknesses = new List<Hand>()
        {
            new Scissors(),
            new Lizard()
        };

        public override List<Hand> GetWeaknesses()
        {
            return weaknesses;
        }
    }
}
