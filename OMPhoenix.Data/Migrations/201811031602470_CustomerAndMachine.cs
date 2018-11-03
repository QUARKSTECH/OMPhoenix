namespace OMPhoenix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndMachine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        MobileNumber = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Machine",
                c => new
                    {
                        MachineId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        MachineModel = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        RunningHours = c.String(nullable: false, maxLength: 50),
                        CurrentLoadingHours = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.MachineId);
            
            DropTable("dbo.ClientDetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientDetail",
                c => new
                    {
                        ClientDetailId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false),
                        CertificateNo = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(nullable: false, maxLength: 200),
                        FatherName = c.String(nullable: false, maxLength: 200),
                        DateOfBirth = c.String(nullable: false, maxLength: 200),
                        Course = c.String(nullable: false, maxLength: 200),
                        Session = c.String(nullable: false, maxLength: 200),
                        Grade = c.String(nullable: false, maxLength: 200),
                        CertificateIssueDate = c.String(nullable: false, maxLength: 200),
                        CertificateName = c.String(maxLength: 200),
                        ProfileImagePath = c.String(nullable: false, maxLength: 300),
                        CertificateImagePath = c.String(nullable: false, maxLength: 300),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ClientDetailId);
            
            DropTable("dbo.Machine");
            DropTable("dbo.Customer");
        }
    }
}
