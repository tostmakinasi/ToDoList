using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;

namespace ToDoList.Core.Repositories
{
    public interface IItemRepository:IGenericRepository<Item>
    {
        Task<List<Item>> GetAllItemsWithStepsAsync();

        Task<Item> GetItemWithSteps(int id);
    }
}
