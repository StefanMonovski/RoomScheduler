using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RoomScheduler.Data.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RoomScheduler.Data.Extensions
{
    public static class SoftDeleteModelBuilderExtension
    {
        public static ModelBuilder ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "entity");
                    var property = Expression.PropertyOrField(parameter, nameof(IDeletable.IsDeleted));
                    var entityNotDeleted = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);

                    entityType.SetQueryFilter(entityNotDeleted);
                }
            }

            return modelBuilder;
        }

        public static void SetSoftDelete(this ChangeTracker changeTracker)
        {
            var entriesDeleted = changeTracker.Entries()
                .Where(x => x.Entity is IDeletable && x.State == EntityState.Deleted);

            foreach (var entityEntry in entriesDeleted)
            {
                ((IDeletable)entityEntry.Entity).IsDeleted = true;
                ((IDeletable)entityEntry.Entity).DeletedOn = DateTime.UtcNow;
                entityEntry.State = EntityState.Modified;
            }
        }
    }
}
