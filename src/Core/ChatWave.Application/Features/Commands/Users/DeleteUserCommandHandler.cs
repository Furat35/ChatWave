using ChatWave.Application.Exceptions;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Commands.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _userService.DeleteUser(request.Id);
            if (isDeleted)
                throw new InternalServerError($"Application Request: Unhandled exception for Request {request} (Handler: {nameof(DeleteUserCommandHandler)} - {DateTime.Now})");
        }
    }
}
