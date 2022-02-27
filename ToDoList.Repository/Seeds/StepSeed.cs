using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Core.Models;

namespace ToDoList.Repository.Seeds
{
    internal class StepSeed : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasData(new Step { Id = 1, ItemId = 1, Title = "Salon", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                 new Step { Id = 2, ItemId = 1, Title = "Salon", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                  new Step { Id = 3, ItemId = 1, Title = "Küçük Oda", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                   new Step { Id = 4, ItemId = 1, Title = "Antre", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                    new Step { Id = 5, ItemId = 1, Title = "Mutfak", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                     new Step { Id = 6, ItemId = 1, Title = "Yatak Odası", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                    new Step { Id = 7, ItemId = 2, Title = "Ispanaklı Tavuk Yemeği", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                   new Step { Id = 8, ItemId = 2, Title = "Zeytin Yağlı Pırasa", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                    new Step { Id = 9, ItemId = 2, Title = "Prinç Pilavı", CreatedDate = DateTime.Today, Status = false, IsDeleted = false },
                     new Step { Id = 10, ItemId = 2, Title = "Mevsim Salata", CreatedDate = DateTime.Today, Status = false, IsDeleted = false });
        }
    }
}
