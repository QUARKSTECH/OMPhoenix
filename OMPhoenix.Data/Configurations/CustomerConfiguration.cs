using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMPhoenix.Data.Configurations
{
    public class CustomerConfiguration : EntityBaseConfiguration<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerConfiguration"/> class.
        /// </summary>
        public CustomerConfiguration()
            : this("dbo")
        {
        }

        public CustomerConfiguration(string schema)
        {
            ToTable("Customer", schema);
            HasKey(x => x.CustomerId);

            Property(x => x.CustomerId).HasColumnName(@"CustomerId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Email).HasColumnName(@"Email").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.MobileNumber).HasColumnName(@"MobileNumber").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
