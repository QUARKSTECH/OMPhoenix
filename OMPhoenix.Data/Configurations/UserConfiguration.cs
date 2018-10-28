using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMPhoenix.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration"/> class.
        /// </summary>

        public UserConfiguration()
            : this("dbo")
        {
        }

        public UserConfiguration(string schema)
        {
            ToTable("User", schema);
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Username).HasColumnName(@"Username").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.Email).HasColumnName(@"Email").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.HashedPassword).HasColumnName(@"HashedPassword").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Salt).HasColumnName(@"Salt").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.IsLocked).HasColumnName(@"IsLocked").IsRequired().HasColumnType("bit"); 
        }
    }
}
