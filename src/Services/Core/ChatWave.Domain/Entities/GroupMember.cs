using ChatWave.Domain.Common;

namespace ChatWave.Domain.Entities
{
    public class GroupMember : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
