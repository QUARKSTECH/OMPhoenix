using OMPhoenix.Entity;
using System;
using System.Data.Entity.Migrations;

namespace OMPhoenix.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OMPhoenixContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OMPhoenixContext context)
        {
            //// create users
            context.UserSet.AddOrUpdate(GenerateAdminUser());
            // create roles
            context.RoleSet.AddOrUpdate(GenerateRoles());
          

        }
        private Role[] GenerateRoles()
        {
            var roles = new[]{
                new Role()
                {
                    RoleName="Staff",
                    IsDeleted=false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                 new Role()
                {
                    RoleName="Admin",
                    IsDeleted=false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            };

            return roles;
        }
       
        private GlobalVariable[] GenerateGlobalVariable()
        {
            var globalVariable = new[]{
                new GlobalVariable()
                {
                    VariableName="WebSite",
                    Value="http://localhost:61499/",
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow,
                    IsDeleted=false
                }
            };
            return globalVariable;
        }


        #region Generate Admin
        private User[] GenerateAdminUser()
        {
            var users = new[]{
                new User()
                {
                    //KeyId=Guid.NewGuid(),
                    Username="admin@yopmail.com",
                    Email="admin@yopmail.com",
                    HashedPassword="",
                    Salt="",                    
                    IsDeleted=false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow,
                    IsLocked=false                    
                }
            };

            return users;
        }
        private UserRole[] GenerateAdminRole()
        {
            var dc = new OMPhoenixContext();
            var userId = dc.UserSet.Find();
            var roleId = dc.RoleSet.Find();
            var userRole = new UserRole[]{
                new UserRole()
                {
                    UserId=userId.UserId,
                    RoleId= roleId.RoleId,                                      
                    IsDeleted=false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow                                        
                }                 
            };

            return userRole;
        }

        #endregion
        
    }
}

