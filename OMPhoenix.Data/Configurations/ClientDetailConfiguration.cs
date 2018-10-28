using OMPhoenix.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMPhoenix.Data.Configurations
{
    public class ClientDetailConfiguration : EntityBaseConfiguration<ClientDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDetailConfiguration"/> class.
        /// </summary>

        public ClientDetailConfiguration()
            : this("dbo")
        {
        }

        public ClientDetailConfiguration(string schema)
        {
            ToTable("ClientDetail", schema);
            HasKey(x => x.ClientDetailId);

            Property(x => x.ClientDetailId).HasColumnName(@"ClientDetailId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KeyId).HasColumnName(@"KeyId").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CertificateNo).HasColumnName(@"CertificateNo").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.FullName).HasColumnName(@"FullName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.FatherName).HasColumnName(@"FatherName").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.DateOfBirth).HasColumnName(@"DateOfBirth").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Course).HasColumnName(@"Course").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Session).HasColumnName(@"Session").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Grade).HasColumnName(@"Grade").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.CertificateIssueDate).HasColumnName(@"CertificateIssueDate").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.CertificateName).HasColumnName(@"CertificateName").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.ProfileImagePath).HasColumnName(@"ProfileImagePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(300);
            Property(x => x.CertificateImagePath).HasColumnName(@"CertificateImagePath").IsRequired().HasColumnType("nvarchar").HasMaxLength(300);
        }
    }
}
