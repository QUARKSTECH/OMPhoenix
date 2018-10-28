namespace SECAdmin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false),
                        RoleName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        Token = c.String(),
                        TokenExpiryDate = c.DateTime(),
                        IsLocked = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ForgotPasswordLog",
                c => new
                    {
                        ForgotPasswordlogID = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false),
                        UserId = c.Long(nullable: false),
                        Guid = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ForgotPasswordlogID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserDetail",
                c => new
                    {
                        UserDetailId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        UserId = c.Long(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CompanyName = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Zipcode = c.String(),
                        CityId = c.Int(),
                        StateId = c.Int(),
                        CountryId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(),
                        DeletedBy = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserDetailId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ClientDetail",
                c => new
                    {
                        ClientDetailId = c.Long(nullable: false, identity: true),
                        KeyId = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserDetail", "UserId", "dbo.User");
            DropForeignKey("dbo.ForgotPasswordLog", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.UserDetail", new[] { "UserId" });
            DropIndex("dbo.ForgotPasswordLog", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropTable("dbo.ClientDetail");
            DropTable("dbo.UserDetail");
            DropTable("dbo.ForgotPasswordLog");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
        }
    }
}
