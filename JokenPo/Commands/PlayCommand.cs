using JokenPo.Models.Enums;
using JokenPo.Models.RequestResponses;
using MediatR;

namespace JokenPo.Commands
{
    public class PlayCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Hand Hand { get; set; }
        
        public PlayCommand(Guid id, Hand hand)
        {
            Id = id;
            Hand = hand; 
        }
    }
}
