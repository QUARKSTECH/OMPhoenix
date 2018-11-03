using OMPhoenix.Entity;
using System;
using System.Data.Entity.Migrations;

namespace OMPhoenix.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OMPhoenixContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OMPhoenixContext context)
        {
            //// create users
            context.UserSet.AddOrUpdate(GenerateAdminUser());
            // create roles
            context.RoleSet.AddOrUpdate(GenerateRoles());
            // create Machine
            context.MachineSet.AddOrUpdate(GenerateMachine());
            // create Customer
            context.CustomerSet.AddOrUpdate(GenerateCustomer());
          

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

        #region:Generate Mchine Data
        private Machine[] GenerateMachine()
        {
            var machine = new Machine[]{
                new Machine()
                {
                    MachineModel="Mac-1",
                    SerialNo="9518",
                    RunningHours="01:32:50",
                    CurrentLoadingHours = "01:32:50",
                    IsDeleted =false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                },
                new Machine()
                {
                    MachineModel="Mac-2",
                    SerialNo="7326",
                    RunningHours="00:51:22",
                    CurrentLoadingHours = "01:32:50",
                    IsDeleted =false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                },
                new Machine()
                {
                    MachineModel="Mac-3",
                    SerialNo="4162",
                    RunningHours="00:24:34",
                    CurrentLoadingHours = "01:32:50",
                    IsDeleted =false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                }
            };

            return machine;
        }
        #endregion

        #region:Generate Customer Data
        private Customer[] GenerateCustomer()
        {
            var customer = new Customer[]{
                new Customer()
                {
                    Name="Carolina Biggleswade",
                    CompanyName="INFO SOFT",
                    Email="caroline@bigg.com",
                    MobileNumber = "1234567890",
                    IsDeleted =false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                },
                new Customer()
                {
                    Name="Tom jones",
                    CompanyName="INFO SOFT",
                    Email="Tom@bigg.com",
                    MobileNumber = "4567890987",
                    IsDeleted =false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                },
                new Customer()
                {
                    Name="Roma Biggleswade",
                    CompanyName="INFO SOFT",
                    Email="Roma@bigg.com",
                    MobileNumber = "7654367809",
                    IsDeleted =false,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                }
            };

            return customer;
        }
        #endregion
    }
}

