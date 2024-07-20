using ChatWave.Application.Dtos.Authentications;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Commands.Authentications
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userToLog = new LoginDto { Username = request.Username, Password = request.Password };
            return await _authenticationService.LoginAsync(userToLog);
        }
    }
}
