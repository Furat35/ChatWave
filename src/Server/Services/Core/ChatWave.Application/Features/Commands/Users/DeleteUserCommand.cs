using MediatR;

namespace ChatWave.Application.Features.Commands.Users
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand()
        {

        }

        public DeleteUserCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
