using ChatWave.Application.Dtos.Authentications;

namespace ChatWave.Application.Persistence
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task<string> RegisterUserAsync(RegisterDto registerDto);
    }
}
