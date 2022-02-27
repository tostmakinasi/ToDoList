using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;

namespace ToDoList.Repository.Seeds
{
    internal class ItemSeed : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                new Item { Id = 1, ItemListId = 1, Title = "Ev Temizliği", CreatedDate = DateTime.Now, Description = "Tüm odalarda toparlama, süpürme, silme ve toz alma işlemlerinin yapılması", StartingDate = DateTime.Today, EndDate = DateTime.Today.AddHours(23), IsDeleted = false, Status = false },
                 new Item { Id = 2, ItemListId = 1, Title = "Akşam Yemeğinin Hazırlanması", CreatedDate = DateTime.Now, Description = "3 Kişilik Yemek Hazırlığı", StartingDate = DateTime.Today, EndDate = DateTime.Today.AddHours(23), IsDeleted = false, Status = false },
                 new Item { Id = 3, ItemListId = 1, Title = "Ikeadan Aldığım Masanın Kurulması", CreatedDate = DateTime.Now, Description = "", StartingDate = DateTime.Today, EndDate = DateTime.Today.AddHours(23), IsDeleted = false, Status = false });
        }
    }
}
