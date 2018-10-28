using System;

namespace OMPhoenix.Entity
{
    /// <summary>
    /// RockRiver User's Role
    /// </summary>
    public class UserRole : IEntityBase
    {
        public long UserRoleId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public long UserId { get; set; }
        public long RoleId { get; set; } 

        //Relationship
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

        //common columns
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
