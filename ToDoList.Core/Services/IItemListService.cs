using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.DTOs;

namespace ToDoList.Core.Services
{
    public interface IItemListService
    {
        Task<List<ItemListWithItemsDto>> GetAllWithItemsAsync();

        Task<List<ItemListWithItemsAndItemsStepsDto>> GetAllWithItemsAndStepsAsync();

        Task<ItemListWithItemsDto> GetItemListByIdWithItemAsync(int id);

        Task<ItemListWithItemsAndItemsStepsDto> GetItemListByIdWithItemAndStepsAsync(int id);
    }
}
