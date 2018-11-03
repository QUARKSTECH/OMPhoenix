using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMPhoenix.Entity
{
    public class Customer : IEntityBase
    {
        public long CustomerId { get; set; }
        public Guid KeyId { get; set; } = new Guid();
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        //common column
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
