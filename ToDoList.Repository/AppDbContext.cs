using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;

namespace ToDoList.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<ItemList> ItemLists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Step> Steps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemList>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemList>().Property(x => x.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ItemList>().HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<Step>().HasKey(x => x.Id);
            modelBuilder.Entity<Step>().Property(x=> x.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Step>().HasQueryFilter(x => x.IsDeleted == false);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[nameof(BaseEntity.IsDeleted)] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(BaseEntity.IsDeleted)] = true;
                        entry.CurrentValues[nameof(BaseEntity.UpdatedDate)] = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.CurrentValues[nameof(BaseEntity.UpdatedDate)] = DateTime.Now;
                        break;
                }
            }
        }
    }
}
