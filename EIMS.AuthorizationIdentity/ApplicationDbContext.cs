using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.AuthorizationIdentity
{
    public class ApplicationDbContext : IdentityDbContext<EIMSUser, EIMSRole, long, EIMSLogin, EIMSUserRole, EIMSClaim>
    {
        public ApplicationDbContext() : base("IdentityConnection")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Map Entities to their tables.
            modelBuilder.Entity<EIMSUser>().ToTable("EIMSUser");
            modelBuilder.Entity<EIMSRole>().ToTable("Role");
            modelBuilder.Entity<EIMSClaim>().ToTable("UserClaim");
            modelBuilder.Entity<EIMSLogin>().ToTable("UserLogin");
            modelBuilder.Entity<EIMSUserRole>().ToTable("UserRole");
            // Set AutoIncrement-Properties
            modelBuilder.Entity<EIMSUser>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EIMSClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EIMSRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Override some column mappings that do not match our default
            modelBuilder.Entity<EIMSUser>().Property(r => r.UserName).HasColumnName("Login");
            modelBuilder.Entity<EIMSUser>().Property(r => r.PasswordHash).HasColumnName("Password");
        }


    }
}
