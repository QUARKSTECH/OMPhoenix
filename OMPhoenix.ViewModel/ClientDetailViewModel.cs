using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMPhoenix.ViewModel
{
    public class ClientDetailViewModel
    {
        public long ClientDetailId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public string CertificateNo { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string DateOfBirth { get; set; }
        public string Course { get; set; }
        public string Session { get; set; }
        public string Grade { get; set; }
        public string CertificateIssueDate { get; set; }
        public string CertificateName { get; set; }
        public string ProfileImagePath { get; set; }
        public string CertificateImagePath { get; set; }

        //common columns
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
