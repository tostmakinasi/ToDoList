using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;
using ToDoList.Core.Repositories;

namespace ToDoList.Repository.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext context):base(context)
        {

        }
        public async Task<List<Item>> GetAllItemsWithStepsAsync()
        {
            return await _context.Items.Include(x=> x.Steps).ToListAsync();
        }

        public async Task<Item> GetItemWithSteps(int id)
        {
            return await _context.Items.Include(x => x.Steps).FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}
