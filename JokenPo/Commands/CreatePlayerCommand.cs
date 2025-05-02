using JokenPo.Models;
using MediatR;

namespace JokenPo.Commands
{
    public class CreatePlayerCommand : IRequest<Player>
    {
        public string Name { get; set; }

        public CreatePlayerCommand(string name)
        {
            Name = name;
        }
    }
}
