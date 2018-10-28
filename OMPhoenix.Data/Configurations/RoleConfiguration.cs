using OMPhoenix.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMPhoenix.Data.Configurations
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
            : this("dbo")
        {
        }

        public RoleConfiguration(string schema)
        {
            ToTable("Role", schema);
            HasKey(x => x.RoleId);

            Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.RoleName).HasColumnName(@"RoleName").HasColumnType("nvarchar").IsRequired().HasMaxLength(500);
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            
        }
    }
}
