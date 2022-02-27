using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;

namespace ToDoList.Core.Repositories
{
    public interface IItemListRepository:IGenericRepository<ItemList>
    {
        Task<List<ItemList>> GetAllWithItemsAsync();

        Task<List<ItemList>> GetAllWithItemsAndStepsAsync();

        Task<ItemList> GetItemListByIdWithItemAsync(int id);

        Task<ItemList> GetItemListByIdWithItemAndStepsAsync(int id);
    }
}
