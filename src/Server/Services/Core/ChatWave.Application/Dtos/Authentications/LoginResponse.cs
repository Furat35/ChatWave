namespace ChatWave.Application.Dtos.Authentications
{
    public record LoginResponseDto(string Id, string Email, string Fullname, string Username, string PhoneNumber, string Token);
}
