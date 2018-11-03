using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMPhoenix.Entity
{
    public class Machine : IEntityBase
    {
        public long MachineId { get; set; }
        public Guid KeyId { get; set; } = new Guid();
        public string MachineModel { get; set; }
        public string SerialNo { get; set; }
        public string RunningHours { get; set; }
        public string CurrentLoadingHours { get; set; }

        //common column
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
