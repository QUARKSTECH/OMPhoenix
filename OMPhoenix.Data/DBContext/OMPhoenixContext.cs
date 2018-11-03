using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OMPhoenix.Data.Configurations;
using OMPhoenix.Entity;

namespace OMPhoenix.Data
{
    public class OMPhoenixContext : DbContext//IdentityDbContext<IdentityUser>
    {
        public OMPhoenixContext()
            : base("OMPhoenix")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OMPhoenixContext, Migrations.Configuration>());
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Machine> MachineSet { get; set; }
        public IDbSet<Customer> CustomerSet { get; set; }

        #endregion

        public virtual void Commit()
        {
            SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new MachineConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
