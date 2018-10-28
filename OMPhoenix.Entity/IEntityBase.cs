using System;

namespace OMPhoenix.Entity
{
    public interface IEntityBase
    {
        Guid KeyId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        long? CreatedBy { get; set; }
        long? DeletedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
