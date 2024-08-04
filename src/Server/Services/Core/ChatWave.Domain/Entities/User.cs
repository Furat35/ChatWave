using ChatWave.Domain.Common;

namespace ChatWave.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? PasswordSalt { get; set; }
        public string? HashedPassword { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        //public ICollection<Role> Roles { get; set; }
    }
}
