using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostgreSql.Models;

namespace PostgreSql.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "ApplicationUser");

            });

            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "ApplicationRole");
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("ApplicationUserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("ApplicationUserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {

                entity.ToTable("ApplicationUserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("ApplicationRoleClaims");

            });
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("ApplicationUserTokens");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}