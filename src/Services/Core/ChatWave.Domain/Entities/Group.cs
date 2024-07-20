using ChatWave.Domain.Common;

namespace ChatWave.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public string GroupPictureUrl { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
    }
}
