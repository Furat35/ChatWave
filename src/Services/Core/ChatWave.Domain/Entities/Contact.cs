using ChatWave.Domain.Common;

namespace ChatWave.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public Guid ContactUserId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
