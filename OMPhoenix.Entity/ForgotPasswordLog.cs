using System;

namespace OMPhoenix.Entity
{
    public class ForgotPasswordLog : IEntityBase
    {
        public long ForgotPasswordlogID { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public long UserId { get; set; }
        public Guid Guid { get; set; } 

        //Relationship
        public virtual User User { get; set; }

        //common columns
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
