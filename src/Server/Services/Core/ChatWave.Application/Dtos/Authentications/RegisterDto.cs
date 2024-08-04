namespace ChatWave.Application.Dtos.Authentications
{
    public record RegisterDto(string Fullname, string Username, string PhoneNumber, string Email, string Password, string ProfilePictureUrl = null);
}
