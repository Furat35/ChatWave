using ChatWave.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatWave.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        public Guid ReceiverId { get; set; }
        [ForeignKey("SenderId")]
        public User Receiver { get; set; }
        public Guid? GroupId { get; set; }
        public Group? Group { get; set; }
        public string MessageText { get; set; }
        public string? MediaUrl { get; set; }
    }
}
