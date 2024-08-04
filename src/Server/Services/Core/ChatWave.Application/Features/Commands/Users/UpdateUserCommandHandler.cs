using AutoMapper;
using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserUpdateDto>(request);
            var isUpdated = await _userService.UpdateUser(user);
            if (isUpdated)
                throw new InternalServerError($"Application Request: Unhandled exception for Request {request} (Handler: {nameof(UpdateUserCommandHandler)} - {DateTime.Now})");
        }
    }
}
