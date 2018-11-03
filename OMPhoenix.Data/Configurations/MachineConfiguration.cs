using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMPhoenix.Data.Configurations
{
    public class MachineConfiguration : EntityBaseConfiguration<Machine>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MachineConfiguration"/> class.
        /// </summary>
        public MachineConfiguration()
            : this("dbo")
        {
        }

        public MachineConfiguration(string schema)
        {
            ToTable("Machine", schema);
            HasKey(x => x.MachineId);

            Property(x => x.MachineId).HasColumnName(@"MachineId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.MachineModel).HasColumnName(@"MachineModel").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.SerialNo).HasColumnName(@"SerialNo").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.RunningHours).HasColumnName(@"RunningHours").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.CurrentLoadingHours).HasColumnName(@"CurrentLoadingHours").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
