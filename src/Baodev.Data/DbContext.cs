using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Baodev.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Baodev.Core.Domain.Content;
using Microsoft.AspNetCore.Identity;

namespace Baodev.Data
{
    public class DbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entityEntry in entries)
            {
                var dateCreatedProperty = entityEntry.Entity.GetType().GetProperty("DateCreated");
                if (entityEntry.State == EntityState.Added && dateCreatedProperty != null)
                {
                    dateCreatedProperty.SetValue(entityEntry.Entity, DateTime.UtcNow);
                }

                var dateModifiedProperty = entityEntry.Entity.GetType().GetProperty("DateModified");
                if (entityEntry.State == EntityState.Modified && dateModifiedProperty != null)
                {
                    dateModifiedProperty.SetValue(entityEntry.Entity, DateTime.UtcNow);
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
