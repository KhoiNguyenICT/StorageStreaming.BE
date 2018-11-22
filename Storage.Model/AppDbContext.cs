using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Storage.Common.Interfaces;
using Storage.Model.Entities;
using Storage.Model.Entities.temp;

namespace Storage.Model
{
    public class AppDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }

        public virtual DbSet<ConfigurationValue> ConfigurationValues { get; set; }

        public virtual DbSet<LoginHistory> LoginHistories { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>()
                .HasOne(bc => bc.Role)
                .WithMany(b => b.Permissions)
                .HasForeignKey(bc => bc.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(bc => bc.Permission)
                .WithMany(b => b.Roles)
                .HasForeignKey(bc => bc.PermissionId);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modified = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var item in modified)
                if (item.Entity is IEntity changedOrAddedItem)
                {
                    if (item.State == EntityState.Added) changedOrAddedItem.CreatedDate = DateTime.Now;
                    changedOrAddedItem.UpdatedDate = DateTime.Now;
                }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}