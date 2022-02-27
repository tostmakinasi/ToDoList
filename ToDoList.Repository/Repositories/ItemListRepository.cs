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
    public class ItemListRepository : GenericRepository<ItemList>, IItemListRepository
    {
        public ItemListRepository(AppDbContext context):base(context)
        {

        }
        public async Task<List<ItemList>> GetAllWithItemsAndStepsAsync()
        {
            return await _context.ItemLists.Include(x=> x.Items).ThenInclude(x=> x.Steps).ToListAsync();
        }

        public async Task<List<ItemList>> GetAllWithItemsAsync()
        {
            return await _context.ItemLists.Include(x => x.Items).ToListAsync();
        }

        public async Task<ItemList> GetItemListByIdWithItemAsync(int id)
        {
            return await _context.ItemLists.Include(x => x.Items).ThenInclude(x => x.Steps).FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<ItemList> GetItemListByIdWithItemAndStepsAsync(int id)
        {
            return await _context.ItemLists.Include(x => x.Items).ThenInclude(x => x.Steps).FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}
