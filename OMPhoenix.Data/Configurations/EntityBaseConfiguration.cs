using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OMPhoenix.Data.Configurations
{
    /// <summary>
    /// Class EntityBaseConfiguration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBaseConfiguration{T}"/> class.
        /// </summary>
        protected EntityBaseConfiguration()
        {
            //HasKey(e => e.ID);
            //Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").IsOptional() ; 
            Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").IsOptional().HasColumnType("datetime2");
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").IsOptional().HasColumnType("datetime2");
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").IsOptional().HasColumnType("bit");
        }
    }
}
