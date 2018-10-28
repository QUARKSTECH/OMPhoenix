using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMPhoenix.Data.Configurations
{
    public class GlobalVariableConfiguration : EntityBaseConfiguration<GlobalVariable>
    {

        public GlobalVariableConfiguration()
            : this("dbo")
        {
        }
        public GlobalVariableConfiguration(string schema)
        {
            ToTable("GlobalVariable", schema);
            HasKey(x => x.GlobalVarId);

            Property(x => x.GlobalVarId).HasColumnName(@"GlobalVarId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.VariableName).HasColumnName(@"VariableName").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.Value).HasColumnName(@"Value").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.DeletedBy).HasColumnName(@"DeletedBy").HasColumnType("bigint").IsOptional();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();

            //HasOptional(a => a.UserMasterCreatedBy).WithMany(b => b.GlobalVariablesCreatedBy).HasForeignKey(c => c.CreatedBy).WillCascadeOnDelete(false);
            //HasOptional(a => a.UserMasterDeletedBy).WithMany(b => b.GlobalVariablesDeletedBy).HasForeignKey(c => c.DeletedBy).WillCascadeOnDelete(false);
        }
    }
}
