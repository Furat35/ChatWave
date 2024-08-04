namespace ChatWave.Application.Dtos.Users
{
    public record UserCreateDto(string Fullname, string Username, string PhoneNumber, string Email, string Password, string ProfilePictureUrl = null);
}
