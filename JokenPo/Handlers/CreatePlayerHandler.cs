namespace JokenPo.Handlers
{
    using JokenPo.Commands;
    using JokenPo.Models;
    using MediatR;

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Player>
    {
        // Simulating database
        private static readonly List<Player> _users = new()
    {
        new Player { Id = 1, Name = "Alice" },
        new Player { Id = 2, Name = "Bob" }
    };

        public async Task<Player> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new Player
            {
                Id = _users.Max(u => u.Id) + 1, // Generate a new Id
                Name = request.Name
            };

            _users.Add(newUser);

            return await Task.FromResult(newUser);
        }
    }
}
