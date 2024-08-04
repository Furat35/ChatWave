using AutoMapper;
using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserCreateDto>(request);
            var userId = await _userService.CreateUserAsync(user);
            if (string.IsNullOrEmpty(userId))
                throw new InternalServerError($"Application Request: Unhandled exception for Request {request} (Handler: {nameof(CreateUserCommandHandler)} - {DateTime.Now})");

            return userId;
        }
    }
}
