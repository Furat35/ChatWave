namespace ChatWave.Application.Dtos.Users
{
    public record UserListDto(string Id, string Fullname, string Username, string PhoneNumber, string Email, bool IsActive);
}
