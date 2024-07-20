using ChatWave.Application.Dtos.Authentications;
using MediatR;

namespace ChatWave.Application.Features.Commands.Authentications
{
    public class LoginUserCommand : IRequest<LoginResponseDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
