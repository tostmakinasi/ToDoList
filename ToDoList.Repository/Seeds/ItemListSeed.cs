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
    internal class ItemListSeed : IEntityTypeConfiguration<ItemList>
    {
        public void Configure(EntityTypeBuilder<ItemList> builder)
        {
            builder.HasData(new ItemList { Title = "Ev İçi Yapılacaklar Listesi", Id = 1, CreatedDate = DateTime.Today.AddDays(-3), IsDeleted = false });
        }
    }
}
