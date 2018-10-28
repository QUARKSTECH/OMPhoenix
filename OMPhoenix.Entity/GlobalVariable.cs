using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMPhoenix.Entity
{
    public class GlobalVariable :IEntityBase
    {
        public long GlobalVarId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public string VariableName { get; set; }
        public string Value { get; set; }

        //common columns
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
