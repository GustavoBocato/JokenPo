using JokenPo.Models.AbstractClasses;
using JokenPo.Models.CommandResponses;
using MediatR;

namespace JokenPo.Commands
{
    public class PlayCommand : IRequest<PlayCommandResponse>
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
