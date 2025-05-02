using MediatR;

namespace JokenPo.Commands
{
    public class DeletePlayerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletePlayerCommand(Guid id)
        {
            Id = id;
        }
    }
}
