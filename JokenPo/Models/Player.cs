using JokenPo.Models.AbstractClasses;

namespace JokenPo.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Hand? Hand { get; set; }
    }
}
