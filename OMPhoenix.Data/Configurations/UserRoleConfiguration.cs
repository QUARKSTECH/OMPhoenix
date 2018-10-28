using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMPhoenix.Data.Configurations
{
    public class UserRoleConfiguration : EntityBaseConfiguration<UserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleConfiguration"/> class.
        /// </summary>
        public UserRoleConfiguration()
            : this("dbo")
        {
        }

        public UserRoleConfiguration(string schema)
        {
            ToTable("UserRole", schema);
            HasKey(x => x.UserRoleId);

            Property(x => x.UserRoleId).HasColumnName(@"UserRoleId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("bigint").IsRequired();
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedBy).HasColumnName(@"DeletedBy").HasColumnType("bigint").IsOptional();
            //Property(x => x.DeletedDate).HasColumnName(@"DeletedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("bigint").IsRequired();


            HasRequired(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(c => c.RoleId).WillCascadeOnDelete(false);
            HasRequired(a => a.User).WithMany(b => b.UserRoles).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
        }
    }
}
