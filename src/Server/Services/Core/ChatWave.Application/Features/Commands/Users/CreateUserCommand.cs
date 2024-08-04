using MediatR;

namespace ChatWave.Application.Features.Commands.Users
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
