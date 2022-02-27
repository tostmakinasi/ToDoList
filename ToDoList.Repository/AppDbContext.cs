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

            modelBuilder.Entity<Step>().HasKey(x => x.Id);
            modelBuilder.Entity<Step>().Property(x=> x.Title).IsRequired().HasMaxLength(100);
        }
    }
}
