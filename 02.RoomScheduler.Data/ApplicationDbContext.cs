using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomScheduler.Data.Extensions;
using RoomScheduler.Data.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RoomScheduler.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            EnableCascadeDelete(builder, false);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            builder.ApplySoftDeleteQueryFilter();
        }

        public override int SaveChanges()
        {
            ChangeTracker.SetSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        private static void EnableCascadeDelete(ModelBuilder builder, bool isEnabled)
        {
            var entityTypes = builder.Model.GetEntityTypes().ToList();

            DeleteBehavior deleteBehavior;
            if (isEnabled)
            {
                deleteBehavior = DeleteBehavior.Cascade;
            }
            else
            {
                deleteBehavior = DeleteBehavior.Restrict;
            }

            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = deleteBehavior;
            }
        }
    }
}
