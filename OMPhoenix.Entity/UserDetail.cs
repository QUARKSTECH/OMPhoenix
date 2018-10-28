using System;

namespace OMPhoenix.Entity
{ 
    public class UserDetail : IEntityBase
    {
        public UserDetail()
        { 

        }
        public long UserDetailId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public long? UserId { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zipcode { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string CountryId { get; set; }
       
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