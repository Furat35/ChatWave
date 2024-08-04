using ChatWave.Application.Dtos.Authentications;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Commands.Authentications
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userToRegister = new RegisterDto(request.Fullname, request.Username, request.PhoneNumber, request.Email, request.Password, request.ProfilePictureUrl);
            var userId = await _authenticationService.RegisterUserAsync(userToRegister);
            if (string.IsNullOrEmpty(userId))
                throw new InternalServerError($"Application Request: Unhandled exception for Request {request} (Handler: {nameof(RegisterUserCommandHandler)} - {DateTime.Now})");

            return userId;
        }
    }
}
