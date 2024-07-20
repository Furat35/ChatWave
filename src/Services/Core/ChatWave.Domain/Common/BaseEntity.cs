namespace ChatWave.Domain.Common
{
    public class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? LastModifiedBy { get; set; }
        public virtual DateTime? LastModifiedDate { get; set; }
        public virtual bool IsActive { get; set; } = true;
    }
}
