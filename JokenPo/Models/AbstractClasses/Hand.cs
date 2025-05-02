namespace JokenPo.Models.AbstractClasses
{
    public abstract class Hand 
    {
        public abstract List<Hand> GetWeaknesses();
        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == this.GetType();
        }
    }
}
