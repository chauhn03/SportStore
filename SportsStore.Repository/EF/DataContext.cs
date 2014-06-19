using SportsStore.Domain;
using SportsStore.Domain.Entities;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SportsStore.Repository.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Category { get; set; }

        public DataContext()
        {
            
        }

        static DataContext()
        {
            Database.SetInitializer(new DatabaseInitialiser());
        }

        /// <summary>
        /// Update Created and Modified timestamps for all new/updated entities
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            var newEntities = objectContext.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                .Where(e => e.Entity is Entity);

            foreach (var e in newEntities)
            {
                var newEntity = (Entity)e.Entity;
                if (newEntity == null)
                    continue;

                if (e.State == EntityState.Added)
                    newEntity.Created = DateTime.Now;

                if (e.State == EntityState.Modified)
                    newEntity.Modified = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}