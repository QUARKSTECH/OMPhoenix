using System;
using System.Collections.Generic;

namespace OMPhoenix.Entity
{
    /// <summary>
    /// RockRiver User Account
    /// </summary>
    public class User : IEntityBase
    {
        public User()
        {
            this.UserDetails = new HashSet<UserDetail>(); 
            this.UserRoles = new HashSet<UserRole>();
            this.ForgotPasswordLogs = new HashSet<ForgotPasswordLog>();           
        }

        public long UserId { get; set; }
        public Guid KeyId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiryDate { get; set; }
        public bool IsLocked { get; set; }
        
        //Relationship
        public virtual ICollection<UserDetail> UserDetails { get; set; } 
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<ForgotPasswordLog> ForgotPasswordLogs { get; set; }
       

        //common columns
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long? CreatedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
