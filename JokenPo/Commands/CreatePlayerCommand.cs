namespace JokenPo.Commands
{
    using JokenPo.Models;
    using MediatR;

    public class CreateUserCommand : IRequest<Player>
    {
        public string Name { get; set; }

        public CreateUserCommand(string name)
        {
            Name = name;
        }
    }
}
