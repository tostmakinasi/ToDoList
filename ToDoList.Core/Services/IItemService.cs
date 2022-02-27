using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;

namespace ToDoList.Core.Services
{
    public interface IItemService
    {
        Task<List<ItemWithStepsDto>> GetAllItemsWithStepsAsync();

        Task<ItemWithStepsDto> GetItemWithSteps(int id);
    }
}
