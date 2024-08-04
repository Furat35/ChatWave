using ChatWave.Application.Dtos.Authentications;
using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Helpers;
using ChatWave.Application.Persistence;
using ChatWave.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChatWave.Infrastructure.Persistence
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;
        private readonly IPasswordGenerationService _passwordGenerationService;

        public AuthenticationService(ITokenGenerator tokenGenerator, IUserService userService, IPasswordGenerationService passwordGenerationService)
        {
            _tokenGenerator = tokenGenerator;
            _userService = userService;
            _passwordGenerationService = passwordGenerationService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userService.Users.GetSingleAsync(_ => _.Username.ToLower() == loginDto.Username.ToLower())
                ?? throw new NotFoundException("User not found!");
            var isValidPassword = _passwordGenerationService.VerifyPassword(user.PasswordSalt, user.HashedPassword, loginDto.Password);
            if (isValidPassword)
            {
                var claims = ConfigureUserClaims(user);
                var token = _tokenGenerator.GenerateToken(claims);

                return new LoginResponseDto(user.Id.ToString(), user.Email, user.Fullname, user.Username, user.PhoneNumber, new JwtSecurityTokenHandler().WriteToken(token));
            }
            throw new BadRequestException("Invalid username or password!");
        }

        public async Task<string> RegisterUserAsync(RegisterDto registerDto)
        {
            var userToRegister = new UserCreateDto(registerDto.Fullname, registerDto.Username, registerDto.PhoneNumber, registerDto.Email, registerDto.Password, registerDto.ProfilePictureUrl);
            var userId = await _userService.CreateUserAsync(userToRegister);

            return userId;
        }

        private List<Claim> ConfigureUserClaims(User user)
        {
            var authClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.Fullname}"),
                    new Claim("Username",$"{user.Username}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Phone", user.PhoneNumber),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(ClaimTypes.Role, Enum.GetName(user.Role))
            };

            return authClaims;
        }
    }
}
