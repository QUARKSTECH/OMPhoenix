using OMPhoenix.Entity;
using System;

namespace OMPhoenix.Entities
{
    public class Error : IEntityBase
    {
        public long ErrorId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public string StackTrace { get; set; }
        //common columns
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
